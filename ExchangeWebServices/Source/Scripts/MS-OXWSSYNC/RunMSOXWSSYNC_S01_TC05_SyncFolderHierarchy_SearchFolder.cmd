@echo off
pushd %~dp0
"%VS120COMNTOOLS%..\IDE\mstest" /test:Microsoft.Protocols.TestSuites.MS_OXWSSYNC.S01_SyncFolderHierarchy.MSOXWSSYNC_S01_TC05_SyncFolderHierarchy_SearchFolder /testcontainer:..\..\MS-OXWSSYNC\TestSuite\bin\Debug\MS-OXWSSYNC_TestSuite.dll /runconfig:..\..\MS-OXWSSYNC\MS-OXWSSYNC.testsettings /unique
pause