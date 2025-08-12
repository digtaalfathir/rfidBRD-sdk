# commsrfidBRD2pc-csharp-sdk

A C# SDK for communicating with a Chinese RFID reader over TCP, enabling developers to send scan/stop commands, parse EPC tag data, and forward collected tags to a remote API.

## 📌 Features
- **TCP Communication**: Connect to the RFID reader via a fixed IP and port.
- **Scan Command**: Start and stop RFID scanning remotely.
- **Tag Parsing**: Decode EPC tag data from the reader's hex output.
- **API Integration**: Send scanned tag data to a specified HTTP API endpoint.
- **Event-Driven**: Receive real-time notifications when new tags are detected.

## 📂 Project Structure
```
/src
 ├── ReaderClient.cs       # TCP client for RFID reader communication
 ├── TagParser.cs          # Utility for parsing EPC data
 ├── ApiService.cs         # Handles HTTP requests to remote API
 ├── Models/               # Data models (Tag, Payload, etc.)
 └── Program.cs             # Example usage / entry point
```

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 SDK or newer
- Visual Studio 2022 / Rider / VS Code with C# extension
- Access to a compatible Chinese RFID reader

### Installation
Clone the repository:
```bash
git clone https://github.com/yourusername/commsrfidBRD2pc-csharp-sdk.git
cd commsrfidBRD2pc-csharp-sdk
```

### Usage Example
```csharp
using CommsRfid;

var reader = new ReaderClient("192.168.1.201", 9090);
reader.OnTagDetected += (sender, tag) =>
{
    Console.WriteLine($"Tag detected: EPC={tag.EPC}, Antenna={tag.Antenna}");
};

await reader.ConnectAsync();
reader.StartScan();

Console.ReadLine();
reader.StopScan();
await reader.DisconnectAsync();
```

### API Payload Example
```json
{
    "reader_id": "C-001",
    "antenna": "1",
    "idHex": ["300833B2DDD9014000000000"],
    "timestamp": "2025-08-12T14:32:45.123+0700"
}
```

## 🛠 Configuration
You can modify the following constants in `Program.cs` or via environment variables:
- `HOST` – The IP address of the RFID reader
- `PORT` – The TCP port of the RFID reader
- `READER_ID` – Unique ID of the RFID reader
- `POST_URL` – Target API endpoint

## 📜 License
This project is licensed under the MIT License.
