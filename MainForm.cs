namespace WFAFakePopupShit;

using Microsoft.Data.SqlClient;

public partial class MainForm : Form
{
    private DateTime lastTimeStamp;

    private string CONSTR = "SERVER=(localdb)\\MSSQLLocalDB;DATABASE=taskdb;";

    List<TaskDTO> currentTasks;

    public MainForm()
    {
        currentTasks = [];

        InitializeComponent();
        this.Load += MainFormLoad;
        timer.Tick += TimerTick;
        lastTimeStamp = GetLastTimeStampFromDB();
        //TODO: save 'lastimestam to file when program closed'
    }

    private void MainFormLoad(object? sender, EventArgs e)
    {
        timer.Start();
        FillTasksDgv();

        MessageBox.Show($"{lastTimeStamp:yyyy-MM-dd HH:mm:ss}");
    }

    private void FillTasksDgv()
    {
        dgvTasks.Rows.Clear();
        using SqlConnection connection = new(CONSTR);
        connection.Open();
        SqlDataReader reader =
            new SqlCommand("SELECT text, checked FROM tasks;", connection)
            .ExecuteReader();
        while (reader.Read()) dgvTasks.Rows.Add(reader[0], reader[1]);
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        DateTime currentLTS = GetLastTimeStampFromDB();
        if (currentLTS <= lastTimeStamp) return;

        timer.Stop();
        using SqlConnection connection = new(CONSTR);
        connection.Open();
        SqlDataReader reader =
            new SqlCommand(
                "SELECT id, text, checked FROM tasks WHERE " +
                $"timestamp > '{lastTimeStamp:yyyy-MM-dd HH:mm:ss}' AND checked = 0", connection)
            .ExecuteReader();
        while (reader.Read())
        {
            currentTasks.Add(new()
            { 
                Id = (int)reader["id"],
                Text = (string)reader["text"],
                Checked = false,
            });
        }

        ManageCurrentTasks();
        FillTasksDgv();

        timer.Start();
    }

    private void ManageCurrentTasks()
    {
        while (currentTasks.Count > 0)
        {
            TaskDTO task = currentTasks.First();

            DialogResult result = MessageBox.Show(
                caption: "Do you allowing this task?",
                text: task.Text,
                icon: MessageBoxIcon.Question,
                buttons: MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using SqlConnection connection = new(CONSTR);
                connection.Open();
                SqlDataAdapter adapter = new()
                {
                    UpdateCommand = new(
                        $"UPDATE tasks SET checked = 1 WHERE id = {task.Id}",
                        connection)
                };
                adapter.UpdateCommand.ExecuteNonQuery();
            }
            currentTasks.Remove(task);
            lastTimeStamp = DateTime.Now;
        }
    }

    private DateTime GetLastTimeStampFromDB()
    {
        using SqlConnection connection = new(CONSTR);
        connection.Open();
        SqlDataReader reader =
            new SqlCommand(
                "SELECT TOP 1 [timestamp] FROM tasks " +
                "ORDER BY [timestamp] DESC;", connection)
            .ExecuteReader();
        if (reader.Read()) return reader.GetDateTime(0);
        throw new Exception("database connection error");
    }
}
