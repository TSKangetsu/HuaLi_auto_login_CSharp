Function Dotnetrun($ins) {
    if ($ins[0] -like "") {
        dotnet.exe HL_Netcore_ver.dll;
    }
    elseif ($ins[0] -like "add_config") {
        dotnet.exe HL_Netcore_ver.dll $ins[0] $ins[1] $ins[2];
    }
    elseif ($ins[0] -like "connect_with_config") {
        dotnet.exe HL_Netcore_ver.dll $ins[0];
    }
    elseif ($ins[0] -like "connect") {
        dotnet.exe HL_Netcore_ver.dll $ins[0] $ins[1] $ins[2];
    }
    elseif ($ins[0] -like "manual_connect") {
        dotnet.exe HL_Netcore_ver.dll $ins[0] $ins[1] $ins[2] $ins[3];
    }
    elseif ($ins[0] -like "disconnect") {
        dotnet.exe HL_Netcore_ver.dll $ins[0];
    }
    elseif ($ins[0] -like "help") {
        dotnet.exe HL_Netcore_ver.dll $ins[0];
    }
    else {
        "args error , please try 'help' ";
    }
}
Dotnetrun($args);