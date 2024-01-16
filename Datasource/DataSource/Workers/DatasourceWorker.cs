namespace DataSource.Workers;
public class DatasourceWorker
{
    private string datasource;
    private bool isEnabled = true;

    public DatasourceWorker(string datasource)
    {
        this.datasource = datasource;
    }

    public void StartWorker()
    {
        while (isEnabled)
        {
            // SFTP scanning logic
            ScanSftpDirectory();

            // Check if disabled
            CheckIfDisabled();

// Sleep or add any necessary delay
Thread.Sleep(5000);
        }
    }

    private void CheckIfDisabled()
    {
        // Check in the database if the worker should be disabled
        // Set isEnabled to false if disabled
    }
    private void ScanSftpDirectory()
    {
        // Check in the database if the worker should be disabled
        // Set isEnabled to false if disabled
    }
}