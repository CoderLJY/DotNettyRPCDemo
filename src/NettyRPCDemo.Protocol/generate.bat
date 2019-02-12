set PROTOC_DIR=C:\Users\linsi\.nuget\packages\grpc.tools\1.18.0\tools\windows_x64\
set MODEL_DIR=.\
set SERVICE_DIR=.\

%PROTOC_DIR%protoc addressbook.proto --csharp_out %MODEL_DIR% --grpc_out %SERVICE_DIR% --plugin=protoc-gen-grpc=%PROTOC_DIR%grpc_csharp_plugin.exe
