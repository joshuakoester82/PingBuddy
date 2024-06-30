# PingBuddy

PingBuddy is a robust network monitoring tool designed to help IT professionals and network administrators keep track of network performance and connectivity. It provides real-time ping monitoring, alerting, and data visualization for multiple network endpoints.

## Features

- **Multi-Job Ping Monitoring**: Monitor multiple network endpoints simultaneously.
- **Real-time Updates**: View ping results in real-time for all monitored jobs.
- **Customizable Alerts**: Set up alerts for high latency and packet loss.
- **Data Visualization**: Visualize ping performance over time with interactive charts.
- **Email Notifications**: Receive email alerts for network issues.
- **Sound Alerts**: Get audio notifications for critical events.
- **Export/Import**: Save and load your ping job configurations.
- **Detailed Network Information**: View comprehensive details about your network interfaces and connections.

## Prerequisites

- Windows operating system
- .NET Framework 4.7.2 or later
- Visual Studio 2019 or later (for development)

## Installation

1. Clone the repository or download the source code.
2. Open the solution file (`PingBuddy.sln`) in Visual Studio.
3. Restore NuGet packages if prompted.
4. Build the solution.
5. Run the application.

## Usage

### Setting Up Ping Jobs

1. Click the "Add Job" button.
2. Enter the hostname or IP address to monitor.
3. Configure job parameters such as interval, timeout, and alert thresholds.
4. Click "Save" to add the job.

### Monitoring

- The main window displays all active ping jobs and their current status.
- The "Current Job Status" panel shows the latest ping result for each job.
- The "Ping Results" panel displays a history of ping results.
- The "Alerts" panel shows any triggered alerts.

### Visualization

1. Click the "View Chart" button to open the visualization window.
2. Select one or more jobs from the list.
3. Choose a date range for the data you want to visualize.
4. Click "Update Chart" to generate the visualization.

### Alerts

- Configure alert thresholds in the job settings.
- Enable email notifications in the settings menu to receive alerts via email.
- Enable sound alerts to receive audio notifications for critical events.

### Exporting/Importing Jobs

- Use the "Export Settings" button to save your current job configurations.
- Use the "Import Settings" button to load previously saved configurations.

## Contributing

Contributions to PingBuddy are welcome! Please feel free to submit pull requests, create issues or spread the word.

## License

[MIT License](LICENSE)

## Acknowledgments

- Thanks to all contributors who have helped shape PingBuddy.
- Special thanks to the .NET community for their invaluable resources and libraries.