# BinaryFormatterDemo
```
Implementing serialization/deserialization with binary formatter
```

> In this repo, i m implementing 3 ways of serialization/deserialization with [binary formatter](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.formatters.binary.binaryformatter) :
>
> :one: BasicSerialization way : models are only decorated with [Serializable attribute](https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute)
>
> :two: CustomSerialization way : models are decorated with [Serializable attribute](https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute) and implement [ISerializable interface](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable)
>
> :three: ThirdPartySerialization way : models are considered as third party classes (can't be modified) so we support serialization through [ISerializationSurrogate interface](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializationsurrogate)
>
> To run code in debug or release mode, type the following commands in your favorite terminal : 
> - `.\App.exe`
> - `.\App.exe default`
> - `.\App.exe Basic`
> - `.\App.exe Custom`
> - `.\App.exe ThirdParty`
>
>
> ![BinaryFormatterDemoScreen](Screenshots/BinaryFormatterDemoScreen.png)
>

**`Tools`** : vs19, net 5.0, json.net, system.text.json, bullseye
