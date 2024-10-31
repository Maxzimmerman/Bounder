namespace Bounder.Models.NoDbModels
{
    public class Message
    {
        private string Text { get; set; }

        public Message(Company company, string costumerName)
        {
            Text = $"Hello {costumerName} {company.CompanyName} wishes you a good Day!";
        }
    }
}
