using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ParaStaf
{
    public partial class ParaStafForm : Form
    {
        private StringBuilder allRunLog = new StringBuilder();
        public ParaStafForm()
        {
            InitializeComponent();
        }

        private void btnAddHost_Click(object sender, EventArgs e)
        {
            if(txtHostAdd.Text!=null && txtHostAdd.Text.Length >0)
            {
                lstHostList.Items.Add(txtHostAdd.Text);
            }
        }

        private void btnDelHost_Click(object sender, EventArgs e)
        {
            if(lstHostList.SelectedIndex>=0)
            {
                String hostName = lstHostList.SelectedItem.ToString();

                int index = lstHostList.SelectedIndex;

                lstHostList.Items.RemoveAt(index);

                if (lstRunResult.Items.Count > index)
                {
                    lstRunResult.Items.RemoveAt(index);
                }

                if(hostOutputMap.ContainsKey(hostName))
                {
                    hostOutputMap.Remove(hostName);
                }

                if(hostRunLogMap.ContainsKey(hostName))
                {
                    hostRunLogMap.Remove(hostName);
                }
            }
        }

        private System.Windows.Forms.ToolTip toolTip;

        private void Form1_Load(object sender, EventArgs e)
        {
           /* txtConsoleOutput.MaxLength = 3000000;*/

            //if c:\staf exsits, add c:\staf\bin to PATH
            if (Directory.Exists("C:\\STAF"))
            {
                Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH")+";C:\\STAF\\bin" );
            }

            loadItemsToListBox("cfg\\HostList.txt", lstHostList);
            loadItemsToListBox("cfg\\SyncFileFolders.txt", lstSyncFileFolders);
            loadItemsToListBox("cfg\\FilesBack.txt", lstFilesBack);

            txtCommand.Text = readText("cfg\\Command.txt");
            txtCheckCondition.Text = readText( "cfg\\CheckCondition.txt") ;
            
            this.WindowState = FormWindowState.Maximized;

        }


        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if(txtFileFolderName.Text!=null && txtFileFolderName.Text.Length>0)
            {
                lstSyncFileFolders.Items.Add(txtFileFolderName.Text);
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if(lstSyncFileFolders.SelectedIndex>=0)
            {
                lstSyncFileFolders.Items.RemoveAt(lstSyncFileFolders.SelectedIndex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            if (!Directory.Exists("cfg"))
            {
                Directory.CreateDirectory("cfg");
            }
            saveItemsToFile("cfg\\HostList.txt", lstHostList);
            saveItemsToFile("cfg\\SyncFileFolders.txt", lstSyncFileFolders);
            saveItemsToFile("cfg\\FilesBack.txt", lstFilesBack);
            saveStringToFile("cfg\\Command.txt", txtCommand.Text);
            saveStringToFile("cfg\\CheckCondition.txt", txtCheckCondition.Text);
        }

        private void saveItemsToFile(String filename, ListBox box)
        {
            FileInfo f = new FileInfo(filename);
            StreamWriter writer = f.CreateText();

            foreach (Object o in box.Items)
            {
                writer.WriteLine(o.ToString());
            }

            writer.Close();
        }

        private void loadItemsToListBox(String filename, ListBox box)
        {
            if (File.Exists(filename))
            {
                StreamReader re = File.OpenText(filename);
                string input = null;
                while ((input = re.ReadLine()) != null)
                {
                    box.Items.Add(input.Trim());
                }
                re.Close();
            }
        }

        private void saveStringToFile(String filename, String text)
        {
            FileInfo f = new FileInfo(filename);
            StreamWriter writer = f.CreateText();

            writer.WriteLine(text);

            writer.Close();
        }

        private String readText(String filename)
        {
            String text = "";
            if (File.Exists(filename))
            {
                StreamReader re = File.OpenText(filename);
                text = re.ReadToEnd();
                re.Close();
            }
            return text;
        }

        private bool quitWithoutSave = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!quitWithoutSave)
            {
                save();
            }
           
        }

        private void btnAddFileBack_Click(object sender, EventArgs e)
        {
            if(txtFilesBack.Text!=null && txtFilesBack.Text.Length>0)
            {
                lstFilesBack.Items.Add(txtFilesBack.Text);
            }
        }

        private void btnDeleteFileBack_Click(object sender, EventArgs e)
        {
            if(lstFilesBack.SelectedIndex>=0)
            {
                lstFilesBack.Items.RemoveAt(lstFilesBack.SelectedIndex);
            }
        }

        private void lstSyncFileFolders_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string fileName in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                lstSyncFileFolders.Items.Add(fileName);
            }
        }

        private void lstSyncFileFolders_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 

        }

        private void lstSyncFileFolders_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstSyncFileFolders.SelectedIndex >= 0)
            {
                this.lstSyncFileFolders.DoDragDrop(this.lstSyncFileFolders.SelectedItem, DragDropEffects.Move);
            }
        }

        private void lstSyncFileFolders_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 
        }

        private void lstSyncFileFolders_DragLeave(object sender, EventArgs e)
        {
//             if (lstSyncFileFolders.SelectedIndex >= 0)
//             {
//                 lstSyncFileFolders.Items.RemoveAt(lstSyncFileFolders.SelectedIndex);
//             }
        }

        class PingInfo
        {
            public ProcessStartInfo startInfo;
            public int index;
            
        }

        private delegate void listBoxHandler(int index, String result);

        private void updateResultListBoxItemResult(int index, String result)
        {
            lstRunResult.Items[index] = result;
        }

        void ping(Object pinfo)
        {
              PingInfo info = (PingInfo) pinfo;

            ProcessStartInfo startInfo = info.startInfo;

            // Start the process with the info we specified.
            // Call WaitForExit and then the using statement will close.
            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit();
                StreamReader reader = exeProcess.StandardOutput;
                String outtext = reader.ReadToEnd();
                if (outtext.Contains("PONG"))
                {
                    listBoxHandler handler = new listBoxHandler(updateResultListBoxItemResult);
                    lstRunResult.Invoke(handler, new Object[] { info.index, "OK" });
                    //lstRunResult.Items[info.index] = "OK";
                }
                else
                {
                    listBoxHandler handler = new listBoxHandler(updateResultListBoxItemResult);
                    lstRunResult.Invoke(handler, new Object[] { info.index, outtext.Replace("\r\n", "") });
                    //lstRunResult.Items[info.index] = outtext.Replace("\r\n", "");
                }
            }
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            // staf 192.168.152.131 ping ping

            lstRunResult.Items.Clear();

            for (int i = 0; i < lstHostList.Items.Count;i++)
            {
                lstRunResult.Items.Add("ping...");
                
                try
                {
                    // Use ProcessStartInfo class
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.CreateNoWindow = true;
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = "staf.exe";
                    startInfo.WorkingDirectory = "C:\\STAF";
                    startInfo.RedirectStandardOutput = true;
                    startInfo.Arguments = "%host ping ping";
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.Arguments = startInfo.Arguments.Replace("%host", lstHostList.Items[i].ToString());
                    PingInfo info = new PingInfo();
                    info.index = i;
                    info.startInfo = startInfo;

                    Thread pingThread = new Thread(    ping      );

                    pingThread.Start(info);

                }
                catch
                {
                    // Log error.
                }

            }  // end of for loop

        }

        /** is output OK, for FS operations */
        private bool isOutputOK(String output)
        {
            output = output.Replace("\r\n", "");
            if (output.Trim("- ".ToCharArray()).Equals("Response") || !output.Contains("Error"))
            {
                return true;
            }
            return false;
        }

        private delegate void TxtHandeler(String text);
        private delegate void Enabler();

        private void enableAdd()
        {
            btnAddHost.Enabled = true;
        }

        private void enableDelete()
        {
            btnDelHost.Enabled = true;
        }

        private void updateText(String text)
        {
            txtResult.Text = text;

            //  focus on the last line of the textbox
            txtResult.SelectionStart = txtResult.Text.Length;
            txtResult.ScrollToCaret();

        }

        private void showLog()
        {
            TxtHandeler handler = new TxtHandeler(updateText);
            //txtResult.Text = runLog.ToString();
            txtResult.Invoke(handler, new Object[] { allRunLog.ToString()});
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            if(chkStafCommand.Checked) // run STAF command other than OS command: 
            {
                //TODO : support multi commands:

                String command = txtCommand.Text.Trim(" \r\n".ToCharArray());

                if (!command.Contains("%host")) // run for only 1 user specified host, and return:
                {
                    String commandWithoutStafPrefix = command.Substring(command.IndexOf(' ') + 1);

                    //running single command, and save output:
                    String output = runStafCmd(commandWithoutStafPrefix, null);
                    txtConsoleOutput.Text = output;
                    return;
                }
            }


            this.showSTAFCommand = chkShowDebugInfo.Checked;
            bool disableParallel = chkDisableParallel.Checked;

            lstRunResult.Items.Clear();
            hostOutputMap.Clear();
            hostRunLogMap.Clear();

            allRunLog = new StringBuilder();
            txtConsoleOutput.Text = "";

            String localName = System.Net.Dns.GetHostName();

            // FIXME: does it get the correct IP address ?? (Use should be able to determine the IP add):
            String localIP = System.Net.Dns.GetHostEntry(localName).AddressList[0].ToString();

            String filesGetBackFolder = "FilesGetBack";

            int i=0;

            if(disableParallel)
            {

                // 1 thread to drive all STAF host one by one
                // Here I use thread to avoid block main thread(GUI) from responding to end user:
                Thread processThread = new Thread(delegate() {

                    btnAddHost.Enabled = false;
                    btnDelHost.Enabled = false;

                    foreach (Object host in lstHostList.Items)
                    {
                        lstRunResult.Items.Add("running...");
                        String hostAdd = host.ToString();
                        HostInfo info = new HostInfo(localIP, filesGetBackFolder, hostAdd, i++);
                        
                        processHost(info);
                    }

//                     btnAddHost.Enabled = true;
//                     btnDelHost.Enabled = true;
                    Enabler addEnabler = new Enabler(enableAdd); 
                    Enabler deleEnabler = new Enabler(enableDelete);
                    btnAddHost.Invoke(addEnabler, new object[] { });
                    btnDelHost.Invoke(deleEnabler,new object[]{});
                });

                processThread.Start();

            }
            else
            {
                btnAddHost.Enabled = false;
                btnDelHost.Enabled = false;

                foreach (Object host in lstHostList.Items)
                {
                    lstRunResult.Items.Add("running...");
                }

                // start an invoker thread to invoke tasks on all STAF hosts, and wait the threads to join
                Thread invoker = new Thread(delegate()
                {
                    Thread[] threads = new Thread[lstHostList.Items.Count];

                    int m=0;

                    // assign one thread to drive each STAF host 
                    foreach (Object host in lstHostList.Items)
                    {
                       
                        String hostAdd = host.ToString();
                        HostInfo info = new HostInfo(localIP, filesGetBackFolder, hostAdd, i++);

                        threads[m] = new Thread(processHost);
                        threads[m++].Start(info);

                    } // end of for each host

                    while(m>0)
                    {
                        threads[--m].Join();
                    }

//                     btnAddHost.Enabled = true;
//                     btnDelHost.Enabled = true;

                    Enabler addEnabler = new Enabler(enableAdd);
                    Enabler deleEnabler = new Enabler(enableDelete);
                    btnAddHost.Invoke(addEnabler, new object[] { });
                    btnDelHost.Invoke(deleEnabler, new object[] { });
                });

                invoker.Start();
            }


        }

        class HostInfo
        {
            public String localIP;
            public String filesGetBackFolder;
            public String hostAdd;
            public int index;
            public HostInfo(String localIP, String filesGetBackFolder, String hostAdd, int index)
            {
                this.localIP = localIP;
                this.filesGetBackFolder = filesGetBackFolder;
                this.hostAdd = hostAdd;
                this.index = index;
            }
        }

        private Dictionary<String, String> hostOutputMap = new Dictionary<string, string>();
        private Dictionary<String, String> hostRunLogMap = new Dictionary<string, string>();

        private void processHost(object obj)
        {
            HostInfo info = (HostInfo) obj;

            String localIP = info.localIP;
            String filesGetBackFolder = info.filesGetBackFolder;
            String hostAdd = info.hostAdd;

            StringBuilder hostRunLog = new StringBuilder();
            bool isOk = true;

            DateTime startTime = DateTime.Now;

            hostRunLog.Append("=====processing Host:" + hostAdd + " at " + startTime + " =====").AppendLine();
            allRunLog.Append("=====processing Host:" + hostAdd + " at " + startTime + " =====").AppendLine();           
            showLog();

            hostRunLog.Append("Step 1. Sync files to remote STAF host: ").Append(hostAdd).Append("...").AppendLine();
            allRunLog.Append("Step 1. Sync files to remote STAF host: ").Append(hostAdd).Append("...").AppendLine();            
            showLog();

            // 1. sync files from local to remote STAF host:
            isOk = syncFileToRemoteHost(hostAdd, hostRunLog, isOk);

            hostRunLog.Append("Step 1 Finished for host: ").Append(hostAdd).AppendLine().AppendLine();
            allRunLog.Append("Step 1 Finished for host: ").Append(hostAdd).AppendLine().AppendLine();
            showLog();

            if (isOk) // if step 1 finished OK
            {
                // local folder for each host to save file/folders got back:
                String folderForHost = filesGetBackFolder + "\\" + hostAdd;
                if (Directory.Exists(folderForHost))
                {
                    Directory.Delete(folderForHost, true);
                }

                //create folder for each host to save file/folders got back:
                Directory.CreateDirectory(folderForHost);

                hostRunLog.Append("Step 2. Run STAF cmd and check result on ").Append(hostAdd).Append("...").AppendLine();
                allRunLog.Append("Step 2. Run STAF cmd and check result on ").Append(hostAdd).Append("...").AppendLine();
                showLog();

                // run STAF command on remote STAF host:
                isOk = runSTAFCommandOnHost(hostAdd, hostRunLog, folderForHost, localIP, isOk);


                hostRunLog.Append("Step 2 Finished for ").Append(hostAdd).AppendLine().AppendLine();
                allRunLog.Append("Step 2 Finished for ").Append(hostAdd).AppendLine().AppendLine();
                showLog();

                if(isOk)  // when step 2 is ok, go to step 3
                {
                    hostRunLog.Append("Step 3. Getting back files/folder to local machine from: ").Append(hostAdd).Append("...").AppendLine();
                    allRunLog.Append("Step 3. Getting back files/folder to local machine from: ").Append(hostAdd).Append("...").AppendLine();
                    showLog();

                    // copy files and folder from remote host:
                    isOk = copyFromRemoteHost(localIP, hostAdd, hostRunLog, isOk, folderForHost);

                    hostRunLog.Append("Step 3 Finished for ").Append(hostAdd).AppendLine().AppendLine();
                    allRunLog.Append("Step 3 Finished for ").Append(hostAdd).AppendLine().AppendLine();
                    showLog();
                }

            }  // step 1 OK, 2, 3 finished

            DateTime stopTime = DateTime.Now;

            /* Compute the duration between the initial and the end time. */
            TimeSpan duration = stopTime - startTime;

            hostRunLog.Append("Total time for processing host: " + hostAdd + " is " + duration).AppendLine();
            allRunLog.Append("Total time for processing host: "+ hostAdd + " is " + duration).AppendLine();
            hostRunLog.Append("=====Finished processing host: " + hostAdd + " at " + stopTime + ", result:" + (isOk ? "OK" : "NOK")).AppendLine();
            allRunLog.Append("=====Finished processing host: " + hostAdd + " at " + stopTime + ", result:" + (isOk ? "OK" : "NOK")).AppendLine();

            showLog();

            hostRunLogMap.Add(hostAdd, hostRunLog.ToString() );

            //update final result on Result List Box:
            if (isOk)
            {
                listBoxHandler handler = new listBoxHandler(updateResultListBoxItemResult);
                lstRunResult.Invoke(handler, new Object[] { info.index, "OK" });
                //lstRunResult.Items[info.index] = "OK";
                
            }
            else
            {
                listBoxHandler handler = new listBoxHandler(updateResultListBoxItemResult);
                lstRunResult.Invoke(handler, new Object[] { info.index, "Failed" });
                //lstRunResult.Items[info.index] = logs;
            }


        }

        // copy files and folder from remote host
        private bool copyFromRemoteHost(String localIP, String hostAdd, StringBuilder hostRunLog, bool isOk, String folderForHost)
        {
            if (chkNoSync.Checked)
            {
                hostRunLog.Append("NO Sync TO/FROM requested").AppendLine();
                allRunLog.Append("NO Sync TO/FROM requested").AppendLine();
                showLog();
                return true;
            }

            // Get back files/folders:
            foreach (Object file in lstFilesBack.Items)
            {
                String filePath = file.ToString();

                // check file type(File/Directory) on remote host:
                // 192.168.1.103 FS GET ENTRY c:\program files\ TYPE
                char entryType = getEntryType(hostAdd, filePath);

                if (entryType == 'D')
                {
                    String parentFolderName = new FileInfo(filePath).Name;
                    //Get back Directory to folderForHost :
                    // use staf to copy directory to local staf host:
                    String cmd = "COPY DIRECTORY %source TODIRECTORY %directory TOMACHINE %host RECURSE KEEPEMPTYDIRECTORIES";
                    cmd = cmd.Replace("%source", filePath);
                    cmd = cmd.Replace("%directory", new FileInfo(folderForHost + "\\" + parentFolderName).FullName);
                    cmd = cmd.Replace("%host", localIP);
                    String output = runStafCmd(hostAdd, "FS", cmd, hostRunLog);

                    if (showSTAFCommand)
                    {
                        hostRunLog.Append(output);
                        allRunLog.Append(output);
                        showLog();
                    }


                    if (!isOutputOK(output))
                    {
                        isOk = false;
                        break;
                    }
                }

                else if (entryType == 'F')
                {
                    //Get back file to folderForHost:
                    //use staf to copy file to local staf host:
                    String cmd = "COPY FILE %source TODIRECTORY %directory TOMACHINE %local";
                    cmd = cmd.Replace("%source", filePath);
                    cmd = cmd.Replace("%directory", new FileInfo(folderForHost).FullName);

                    cmd = cmd.Replace("%local", localIP);
                    String output = runStafCmd(hostAdd, "FS", cmd,hostRunLog);

                    if (showSTAFCommand)
                    {
                        hostRunLog.Append(output);
                        allRunLog.Append(output);
                        showLog();
                    }


                    if (!isOutputOK(output))
                    {
                        isOk = false;
                        break;
                    }
                }
                else
                {
                    hostRunLog.Append("\n\n Error get entry type for: " + filePath).AppendLine();
                    allRunLog.Append("\n\n Error get entry type for: " + filePath).AppendLine();
                    showLog();

                    isOk = false;
                }
            }
            return isOk;
        }

        //run STAF command on remote STAF host
        private bool runSTAFCommandOnHost(String hostAdd, StringBuilder hostRunLog, String folderForHost, String localIP, bool isOk)
        {
            try
            {                
                // when use pure STAF command, do not support multi commands:

                if (chkStafCommand.Checked)
                {
                    String outFile = "C:\\" + String.Format("{0:yyyy-MMdd-HHmmss}", DateTime.Now) + ".staf.txt";

                    //run simple STAF commands on each host:
                    String command = txtCommand.Text.Trim(" \r\n".ToCharArray());

                    // %host could occur in user input STAF command:
                    command = command.Replace("%host", hostAdd); //replace the host name

                    // for process command, add STDERRTOSTDOUT and stdout %out
                    String lowerCmd = command.ToLower();
                    if(lowerCmd.Contains("process"))  // for running process, would redirect the console output and check result:
                    {
                        if(!lowerCmd.Contains("stderrtostdout"))
                        {
                            command += " STDERRTOSTDOUT ";
                        }

                        // add stdout %out
                        command += " stdout " + outFile;

                        if(!lowerCmd.Contains("wait"))
                        {
                            command += " WAIT";
                        }

                        if(lowerCmd.StartsWith("staf"))
                        {
                            // get command Without "staf" Prefix:
                            command = command.Substring(command.IndexOf(' ') + 1);
                        }

                        String output = runStafCmd(command, hostRunLog);

                        if (showSTAFCommand)
                        {
                            hostRunLog.Append("STAF cmd response: ").AppendLine().Append(output);
                            allRunLog.Append("STAF cmd response:").AppendLine().Append(output);
                            showLog();
                        }

                        if(!isOutputOK(output))
                        {
                            return false;
                        }

                        isOk = checkRegexOnConsoleOutput(outFile, folderForHost, localIP, hostAdd, hostRunLog, isOk);

                        // clean log file on remote STAF host:
                        String cleanCmdWithoutPrefix = " %host FS DELETE ENTRY %filename CONFIRM";
                        cleanCmdWithoutPrefix = cleanCmdWithoutPrefix.Replace("%host", hostAdd);
                        cleanCmdWithoutPrefix = cleanCmdWithoutPrefix.Replace("%filename", outFile);
                        runStafCmd(cleanCmdWithoutPrefix, null);
                    }
                    else  // for running other services besides PROCESS, would not check result:
                    {
                        String commandWithoutStafPrefix = command.Substring(command.IndexOf(' ') + 1);

                        String output = runStafCmd(commandWithoutStafPrefix, hostRunLog);

                        if (showSTAFCommand)
                        {
                            hostRunLog.Append("STAF cmd response: ").AppendLine().Append(output);
                            allRunLog.Append("STAF cmd response:").AppendLine().Append(output);
                            showLog();
                        }

                        if (!isOutputOK(output))
                        {
                            return false;
                        }
                    }

                }
                else  // parse user input normal command to STAF command , support multi commands:
                    // the last commands result would be checked 
                {
                    String stdoutFile = "";

                    String commands = txtCommand.Text.Trim(" \r\n".ToCharArray());

                    StringReader reader = new StringReader(commands);

                    String inputCmd ;
                    int lines = 0;
                    while((inputCmd=reader.ReadLine())!=null)
                    {
                        inputCmd = inputCmd.Trim(" \r\n".ToCharArray());

                        if (inputCmd == null || inputCmd.Length<=0)
                        {
                            continue;
                        }

                        String outFilePrefix = inputCmd;
                        String namePart = inputCmd;

                        if (inputCmd.IndexOf('\\') > 0 && inputCmd.IndexOf('\\') < inputCmd.Length)
                        {
                            namePart = inputCmd.Substring(inputCmd.LastIndexOf('\\') + 1);
                        }

                        if (namePart.IndexOf(' ') > 0)
                        {
                            outFilePrefix = namePart.Substring(0, namePart.IndexOf(' '));
                        }
                        else
                        {
                            outFilePrefix = namePart;
                        }

                        stdoutFile = "C:\\" + outFilePrefix+"." + String.Format("{0:yyyy-MMdd-HHmmss}", DateTime.Now) + ".txt";
                        lines++;

                        // run one OS command on remote STAF host, and redirect output to outFile
                        String output = processOneOSCommand(hostAdd, hostRunLog, stdoutFile, inputCmd);

                        // copy output file (outFile) to local :
                        copyFileToLocal(stdoutFile, folderForHost, localIP, hostAdd, hostRunLog);

                        // clean output file on remote STAF host:
                        String cleanCmdWithoutPrefix = " %host FS DELETE ENTRY %filename CONFIRM";
                        cleanCmdWithoutPrefix = cleanCmdWithoutPrefix.Replace("%host", hostAdd);
                        cleanCmdWithoutPrefix = cleanCmdWithoutPrefix.Replace("%filename", stdoutFile);
                        runStafCmd(cleanCmdWithoutPrefix, null);

                        if (!isOutputOK(output))
                        {
                            return false;
                        }

                    }
                    
                    //runStafCmd(hostAdd, "DELAY", "DELAY 2s");

                    if (lines > 0)
                    {
                        isOk = checkRegexOnConsoleOutput(stdoutFile, folderForHost, localIP, hostAdd, hostRunLog, isOk);
                    }

                }

            }
            catch (Exception ex)
            {
                txtConsoleOutput.Text = ex.ToString();
            } 
            
            return isOk;
        }

        private String processOneOSCommand(String hostAdd, StringBuilder hostRunLog, String outFile, String inputCmd)
        {
            //Run staf command:
            // support format 1: 
            // staf 192.168.1.103 process start shell command c:\dcerat\case.bat PARMS 551020 
            // WAIT STDERRTOSTDOUT RETURNSTDOUT WORKDIR c:\dcerat
            // format 2: staf 192.168.1.103 process start shell command "java -version" WAIT
            // format 3: staf 192.168.1.103 process start shell command hello.exe WAIT
            //String inputCmd = txtCommand.Text.Trim(" \r\n".ToCharArray());
            String command = inputCmd;  // command to run in STAF command
            String parms = "";
            String workdir = "";

            // Here because on windows, RETURNSTDOUT not work always, 
            // so I use stdout to redirect the command output to a random file under C:\,
            // and then get back the output file by STAF command
            // START SHELL COMMAND ... STDERRTOSTDOUT RETURNSTDOUT
            String stafCmd = "START SHELL COMMAND %cmd %parms STDERRTOSTDOUT stdout %out  WAIT  %workdir ";

            //parse command and param from textbox input command:
            if (inputCmd.Contains(" "))
            {
                command = inputCmd.Substring(0, inputCmd.IndexOf(' '));

                if (inputCmd.Length > inputCmd.IndexOf(' ') + 1)
                {
                    parms = "PARMS " + inputCmd.Substring(inputCmd.IndexOf(' ') + 1);
                }
            }

            //parse WORKDIR:
            if (command.LastIndexOf('\\') > 0)
            {
                workdir = "WORKDIR " + command.Substring(0, command.LastIndexOf('\\'));
            }

            stafCmd = stafCmd.Replace("%cmd", command);
            stafCmd = stafCmd.Replace("%parms", parms);
            stafCmd = stafCmd.Replace("%out", outFile);

            stafCmd = stafCmd.Replace("%workdir", workdir);

            // run STAF command on remote STAF host:
            String output = runStafCmd(hostAdd, "PROCESS", stafCmd, hostRunLog);

            if (showSTAFCommand)
            {
                hostRunLog.Append("STAF cmd response: ").AppendLine().Append(output);
                allRunLog.Append("STAF cmd response:").AppendLine().Append(output);
                showLog();
            }
            return output;
        }

        // check Regext on console output, console output of STAF command has been saved to local consoleOutputFile
        private bool checkRegexOnConsoleOutput(String consoleOutputFile, String folderForHost, String localIP, String hostAdd, StringBuilder hostRunLog, bool isOk)
        {

/*            copyFileToLocal(consoleOutputFile, folderForHost, localIP, hostAdd, hostRunLog);*/

            // check result against console output log:
            String logOnLocal = new FileInfo(folderForHost).FullName + "\\" + new FileInfo(consoleOutputFile).Name;
            if (File.Exists(logOnLocal))
            {
                String consoleOutput = new StreamReader(logOnLocal).ReadToEnd();
                hostOutputMap.Add(hostAdd, consoleOutput);

                if (!chkNoCheck.Checked)  // check the console output if "No Check" not selected:
                {
                    //check result against console output of command run in remote STAF host:
                    Regex regex = new Regex(txtCheckCondition.Text.Trim(), RegexOptions.Multiline);

                    if (regex.IsMatch(consoleOutput))
                    {
                        isOk = true;
                        hostRunLog.Append("Output checked successfully!").AppendLine();
                        allRunLog.Append("Output checked successfully!").AppendLine();
                        showLog();
                    }
                    else  // failed to check result:
                    {
                        isOk = false;

                        String failureMsgOfCheckResult = "Failed to check console output again regular expression! Expected: " + txtCheckCondition.Text.Trim();
                        hostRunLog.Append(failureMsgOfCheckResult).AppendLine();
                        allRunLog.Append(failureMsgOfCheckResult).AppendLine();
                        showLog();
                    }
                } // finished checking output
 
            }
            else
            {
                isOk = false;

                String failureMsgOfGettingLogs = "Failed to get output log from remote STAF host :" + hostAdd;
                hostRunLog.Append(failureMsgOfGettingLogs).AppendLine();
                allRunLog.Append(failureMsgOfGettingLogs).AppendLine();
                showLog();
                //logs += "\n\n Attempted to read logOnLocal path: "+ logOnLocal;
            } 
            
            return isOk;
        }

        private void copyFileToLocal(String consoleOutputFile, String folderForHost, String localIP, String hostAdd, StringBuilder hostRunLog)
        {
            //get back console output(outFile) to local machine by STAF command :
            String cmd = "COPY FILE %source TODIRECTORY %directory TOMACHINE %local";
            cmd = cmd.Replace("%source", consoleOutputFile);
            cmd = cmd.Replace("%directory", new FileInfo(folderForHost).FullName);

            cmd = cmd.Replace("%local", localIP);
            String response = runStafCmd(hostAdd, "FS", cmd, hostRunLog);

            if (showSTAFCommand)
            {
                hostRunLog.Append("getting back console output response: ").AppendLine().Append(response);
                allRunLog.Append("getting back console output response: ").AppendLine().Append(response);
                showLog();
            }
        }

        // sync files from local to remote STAF host:
        private bool syncFileToRemoteHost(String hostAdd, StringBuilder hostRunLog, bool isOk)
        {
            if(chkNoSync.Checked)
            {
                hostRunLog.Append("NO Sync TO/FROM requested").AppendLine();
                allRunLog.Append("NO Sync TO/FROM requested").AppendLine();
                showLog();
                return true;
            }

            foreach (Object file in lstSyncFileFolders.Items)
            {
                String filePath = file.ToString();

                if (Directory.Exists(filePath))
                {
                    // use staf to syn directory to remote staf host:
                    String cmd = "COPY DIRECTORY %source TODIRECTORY %source TOMACHINE %host RECURSE KEEPEMPTYDIRECTORIES";
                    cmd = cmd.Replace("%source", filePath);
                    cmd = cmd.Replace("%host", hostAdd);
                    String output = runStafCmd("local", "FS", cmd, hostRunLog);

                    if (showSTAFCommand)
                    {
                        hostRunLog.Append(output);
                        allRunLog.Append(output);
                        showLog();
                    }


                    if (!isOutputOK(output))
                    {
                        isOk = false;
                        break;
                    }

                }
                else
                {
                    // create directory firstly on Remote Host if directory not exist:
                    String parentFolder = new FileInfo(filePath).DirectoryName;
                    String createFolder = "CREATE DIRECTORY %name FULLPATH";// [FAILIFEXISTS]
                    createFolder = createFolder.Replace("%name", parentFolder);
                    runStafCmd(hostAdd, "FS", createFolder, hostRunLog);

                    //use staf to syn file to remote staf host:
                    String cmd = "COPY FILE %source TOFILE %source TOMACHINE %host";
                    cmd = cmd.Replace("%source", filePath);
                    cmd = cmd.Replace("%host", hostAdd);
                    String output = runStafCmd("local", "FS", cmd, hostRunLog);

                    if (showSTAFCommand)
                    {
                        hostRunLog.Append(output);
                        allRunLog.Append(output);
                        showLog();
                    }


                    if (!isOutputOK(output))
                    {
                        isOk = false;
                        break;
                    }
                }

            }// end of for each file/folder to sync before run command
            return isOk;
        }

        // get entry type of a name by "staf host FS get entry"
        public char getEntryType(String host, String fsEntryName)
        {
            String cmd = "GET ENTRY %entryName TYPE";
            cmd = cmd.Replace("%entryName", fsEntryName);

            String result = runStafCmd(host, "FS", cmd, null);
            result = result.Replace("\r\n", "");
            result = result.Trim("- \0".ToCharArray());

            return result[result.Length - 1];
        }
        private bool showSTAFCommand = false;

        // run STAF command, and append log to hostRunLog, if hostRunLog is null, would not save log to hostRunLog:
        private String runStafCmd(String commandWithoutStafPrefix, StringBuilder hostRunLog)
        {
            StringBuilder output = new StringBuilder(1024);
            try
            {
                // Use ProcessStartInfo class
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "staf.exe";
                startInfo.WorkingDirectory = "C:\\STAF";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = false;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = commandWithoutStafPrefix;

                if (showSTAFCommand)
                {
                    if (null != hostRunLog )
                    {
                        hostRunLog.Append("running staf cmd: staf" + startInfo.Arguments).AppendLine();
                    }
                    allRunLog.Append("running staf cmd: staf" + startInfo.Arguments).AppendLine();
                    showLog();
                }
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();

                    StreamReader reader = exeProcess.StandardOutput;
                    output.Append(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                output.Append(e.ToString());
            }


            return output.ToString();
        }

        private String runStafCmd(String host, String service, String parameters, StringBuilder hostRunLog)
        {
            return runStafCmd(" " + host + " " + service + " " + parameters, hostRunLog);
        }

        private void lstRunResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRunResult.SelectedIndex >= 0)
            {
                txtResult.Text = lstRunResult.SelectedItem.ToString();
                String hostName = lstHostList.Items[lstRunResult.SelectedIndex].ToString();
                if(hostOutputMap.ContainsKey(hostName))
                {
                    txtConsoleOutput.Text = hostOutputMap[hostName];
                }
                else
                {
                    txtConsoleOutput.Text = "";
                }

                if(hostRunLogMap.ContainsKey(hostName))
                {
                    txtResult.Text = hostRunLogMap[hostName];
                }
                else
                {
                    txtResult.Text = lstRunResult.SelectedItem.ToString(); // for PING, show result
                }
            }
        }

        private void lstFilesBack_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void lstFilesBack_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 
        }

        private void lstFilesBack_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string fileName in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                lstFilesBack.Items.Add(fileName);
            }
        }

        private void btnShowRunLog_Click(object sender, EventArgs e)
        {
            showLog();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnQuitWithoutSave_Click(object sender, EventArgs e)
        {
            this.quitWithoutSave = true;
            this.Close();
        } // end of func

    }
}