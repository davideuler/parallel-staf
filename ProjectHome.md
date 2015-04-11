**Parallel STAF - Run your tasks on multi platforms parallely in an intuitive way**

STAF is a great open source tool for testing and software deploy.

STAX is good for submiting XML format STAF jobs to STAF host.

How about an GUI for Parallel jobs on multi platforms? How to perform one of the following jobs:

1.To deploy software to different machines in different platforms ( e.g. install JDK, install hotfix.) and check the deployed result.

2.To submit command to a dozen STAF hosts in multi platforms (Windows XP, Windows 7, Windows Vista, Ubuntu Linux, Fedora, Suse, Gentoo ...) and check the result.  e.g. whether the output matches a specified Regular expression.

3.To run testcases parallelly on multi platforms.

4.Other situations you need to run Jobs on different/many machines (in the same or different OS) automatically/parallelly, and check the jobs result.

For perform these jobs gracefully and intuitively, I created **Parallel STAF**.

**Features of Parallel STAF**:

1.Support parallel submission of commands to different STAF host of multi platform.

2.Support file/folders to be copied to STAF host before run commands.

3.Support commands output check (regular expressions) run on each remote STAF host.

4.Support intuitive way of command running result on each STAF host.

5.Suppport file/folders to be copied from STAF host after commands run, so it would be easier for analyze logs, manually checking result, and backup running results.


For rapid development, Parallel STAF is implemented in C#.