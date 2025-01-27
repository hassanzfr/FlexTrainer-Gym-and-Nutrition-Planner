using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace flextrainer
{
    public partial class reports : Form
    {
        public reports()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();

            string query = "";
            switch (selectedOption)
            {
                case "Option 1":
                    query = "SELECT * FROM member JOIN trainer_works_for_gym ON member.userId = trainer_works_for_gym.userId WHERE trainer_works_for_gym.gymId = 1 AND trainer_works_for_gym.userId = 'User5';";
                    break;
                case "Option 2":
                    query = "SELECT * FROM member JOIN member_follows_plan ON member.userId = member_follows_plan.memberId WHERE member.gymId = 1 AND member_follows_plan.planId = 1;";
                    break;
                case "Option 3":
                    query = "SELECT * FROM member JOIN member_follows_plan ON member.userId = member_follows_plan.memberId JOIN trainer_works_for_gym ON member.userId = trainer_works_for_gym.userId WHERE trainer_works_for_gym.userId = 'User5' AND member_follows_plan.planId = 1;";
                    break;
                case "Option 4":
                    query = "SELECT COUNT(*) FROM member JOIN daily_routine_contains_exercise ON daily_routine_contains_exercise.drID = member.userId JOIN exercise ON daily_routine_contains_exercise.exName = exercise.exName WHERE member.gymId = 1 AND exercise.exName = 'Exercise2';";
                    break;
                case "Option 5":
                    query = "SELECT * FROM diet_plan JOIN daily_target_meal ON diet_plan.planId = daily_target_meal.dtID JOIN meal ON daily_target_meal.mealName = meal.mealName JOIN food_items ON meal.mealName = food_items.itemName WHERE meal.purpose = 'Breakfast' AND food_items.calories < 500;";
                    break;
                case "Option 6":
                    query = "SELECT * FROM diet_plan JOIN daily_target_meal ON diet_plan.planId = daily_target_meal.dtID JOIN meal ON daily_target_meal.mealName = meal.mealName JOIN food_items ON meal.mealName = food_items.itemName WHERE food_items.carbs < 300;";
                    break;
                case "Option 7":
                    query = "SELECT * FROM workout_plan JOIN daily_routine_contains_exercise ON workout_plan.planId = daily_routine_contains_exercise.drID JOIN exercise ON daily_routine_contains_exercise.exName = exercise.exName WHERE exercise.exName != 'Exercise2';";
                    break;
                case "Option 8":
                    query = " SELECT * FROM diet_plan JOIN daily_target_meal ON diet_plan.planId = daily_target_meal.dtID JOIN meal ON daily_target_meal.mealName = meal.mealName WHERE meal.mealName NOT IN (SELECT allName FROM allergen WHERE allName = 'Peanuts');";
                    break;
                case "Option 9":
                    query = "SELECT * FROM membership WHERE startDate >= DATEADD(month, -3, GETDATE());";
                    break;
                case "Option 10":
                    query = "SELECT gymId, COUNT(*) as TotalMembers FROM member WHERE gymId IN (1, 2) AND memId IN (SELECT memId FROM membership WHERE startDate >= DATEADD(month, -6, GETDATE())) GROUP BY gymId;";
                    break;
                case "Option 11":
                    query = "SELECT * FROM member JOIN membership ON member.memId = membership.memId WHERE member.gymId = 1 AND DATEDIFF(year, membership.startDate, GETDATE()) > 1;";
                    break;
                case "Option 12":
                    query = "SELECT AVG(rating) FROM trainer JOIN trainer_works_for_gym ON trainer.userId = trainer_works_for_gym.userId WHERE trainer_works_for_gym.gymId = 1;";
                    break;
                case "Option 13":
                    query = "SELECT * FROM trainer WHERE NoOfClients > 10;";
                    break;
                case "Option 14":
                    query = "SELECT COUNT(*) FROM member_follows_plan WHERE planId = 1;";
                    break;
                case "Option 15":
                    query = "SELECT * FROM member JOIN member_follows_plan ON member.userId = member_follows_plan.memberId JOIN diet_plan ON member_follows_plan.planId = diet_plan.planId JOIN daily_target_meal ON diet_plan.planId = daily_target_meal.dtID JOIN meal ON daily_target_meal.mealName = meal.mealName JOIN food_items ON meal.mealName = food_items.itemName GROUP BY member.userId HAVING SUM(food_items.calories) < 2000;";
                    break;
                case "Option 16":
                    query = "SELECT gymId, COUNT(*) as TotalMembers FROM member WHERE memId IN (SELECT memId FROM membership WHERE startDate >= DATEADD(year, -1, GETDATE())) GROUP BY gymId ORDER BY TotalMembers DESC LIMIT 1;";
                    break;
                case "Option 17":
                    query = "SELECT * FROM member LEFT JOIN workoutlog ON member.userId = workoutlog.memberId WHERE workoutlog.wDate < DATEADD(month, -1, GETDATE()) OR workoutlog.wDate IS NULL;";
                    break;
                case "Option 18":
                    query = "SELECT goal, COUNT(*) as Count FROM workout_plan GROUP BY goal ORDER BY Count DESC LIMIT 1;";
                    break;
                case "Option 19":
                    query = "SELECT * FROM gym JOIN gym_feedback ON gym.gymId = gym_feedback.gymId WHERE gym_feedback.rating < 3;";
                    break;
                case "Option 20":
                    query = "SELECT COUNT(*) FROM member JOIN membership ON member.memId = membership.memId WHERE membership.startDate >= DATEADD(month, -1, GETDATE());";
                    break;
            }

            // Execute the query and display results in the data grid view
            ExecuteQueryAndDisplayResults(query);
        }
        private void ExecuteQueryAndDisplayResults(string query)
        {
            // Create a DataTable to store the results
            DataTable resultTable = new DataTable();

            // Create a SqlConnection using your connection string
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AAOMRCI\\SQLEXPRESS;Initial Catalog=flextrainer;Integrated Security=True;Encrypt=False"))
            {
                // Create a SqlCommand with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Create a SqlDataAdapter to fill the DataTable with the query results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            // Open the connection
                            connection.Open();

                            // Fill the DataTable with the query results
                            adapter.Fill(resultTable);
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = resultTable;
        }

    }
}
