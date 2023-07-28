using FormsApp.Core.Application;
using FormsApp.Core.DB;
using FormsApp.Core.Enums;
using FormsApp.Core.IoCContainer;
using FormsApp.Core.Models;
using FormsApp.Core.Repos;

using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FormsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IoC.RegisterStatic<ApplicationViewModel>();
            DBContext context = new DBContext("Database.db");
            IoC.RegisterStatic(context);
            IoC.RegisterStatic<CompanyPositionRepo>();
            IoC.RegisterStatic<IndustrySizeRepo>();
            IoC.RegisterStatic<OptionsRepo>();
            IoC.RegisterStatic<CategoriesRepo>();
            IoC.RegisterStatic<IndustryRepo>();
            IoC.RegisterStatic<CriteriaRepo>();
            IoC.RegisterStatic<QuestionsRepo>();
            IoC.RegisterStatic<RecommendationsRepo>();

            /*

            IoC.Get<CompanyPositionRepo>().Create(new List<CompanyPosition>()
            {
                new CompanyPosition("CEO"),
                new CompanyPosition("CTO"),
                new CompanyPosition("Technical Officer"),
            });

            IoC.Get<IndustrySizeRepo>().Create(new List<IndustrySize>()
            {
                new IndustrySize("0-10"),
                new IndustrySize("11-20"),
                new IndustrySize("21-50"),
                new IndustrySize("Over 50"),
            });

            IoC.Get<IndustryRepo>().Create(new List<Industry>()
            {
                new Industry("Healthcare"), // 1
                new Industry("Finance"), // 2
                new Industry("Manufacturing"), // 3
                new Industry("Education"), // 4
                new Industry("Legal"), // 5
            });

            IoC.Get<CategoriesRepo>().Create(new List<Category>()
            {
                new Category("General"),
                new Category("Accuracy"), // 2
                new Category("Bias"), // 3
                new Category("Privacy and Data Protection"),// 4
                new Category("Responsibility and Accountability"), // 5
                new Category("Interpretability"), // 6
                new Category("Autonomy and Human Agency"), // 7
                new Category("Social Impact"), // 8
                new Category("Robustness and Safety"), // 9
                new Category("Transparency and Explainability"), //10
            });

            //Defining the criteria
            IoC.Get<CriteriaRepo>().Create(new List<Criteria>()
            {
                //Criteria for Healthcare
                new Criteria(1, 2, 3, 9.5),
                new Criteria(1, 3, 3, 9.2),
                new Criteria(1, 4, 3, 9),
                new Criteria(1, 5, 3, 8.5),
                new Criteria(1, 6, 2, 7),
                new Criteria(1, 7, 2, 9),
                new Criteria(1, 8, 2, 8.5),
                new Criteria(1, 9, 3, 9.5),
                new Criteria(1, 10, 3, 8),

                //Criteria for Finance
                new Criteria(2, 2, 3, 9.8),
                new Criteria(2, 3, 3, 9.5),
                new Criteria(2, 4, 3, 9),
                new Criteria(2, 5, 3, 9),
                new Criteria(2, 6, 2, 7.5),
                new Criteria(2, 7, 2, 9),
                new Criteria(2, 8, 2, 8),
                new Criteria(2, 9, 3, 9.5),
                new Criteria(2, 10, 3, 8.5),

                //Criteria for Manufacturing
                new Criteria(3, 2, 3, 9.7),
                new Criteria(3, 3, 3, 9.6),
                new Criteria(3, 4, 3, 9),
                new Criteria(3, 5, 3, 9.5),
                new Criteria(3, 6, 2, 7),
                new Criteria(3, 7, 2, 9.5),
                new Criteria(3, 8, 2, 8.5),
                new Criteria(3, 9, 3, 9.8),
                new Criteria(3, 10, 3, 8),

                //Criteria for Education
                new Criteria(4, 2, 3, 9.5),
                new Criteria(4, 3, 3, 9.6),
                new Criteria(4, 4, 3, 9),
                new Criteria(4, 5, 3, 8.5),
                new Criteria(4, 6, 2, 7.5),
                new Criteria(4, 7, 2, 9),
                new Criteria(4, 8, 2, 8.5),
                new Criteria(4, 9, 3, 9.5),
                new Criteria(4, 10, 3, 8),

                //Criteria for Legal
                new Criteria(4, 2, 3, 9.6),
                new Criteria(4, 3, 3, 9.7),
                new Criteria(4, 4, 3, 9.5),
                new Criteria(4, 5, 3, 9),
                new Criteria(4, 6, 2, 8),
                new Criteria(4, 7, 2, 9),
                new Criteria(4, 8, 2, 7),
                new Criteria(4, 9, 3, 9.5),
                new Criteria(4, 10, 3, 8.5),
            });

            IoC.Get<QuestionsRepo>().Create(new List<Question>()
            {
                new Question()
                {
                    CategoryId = 1,
                    Number = 1,
                    Type = QuestionType.Dropdown,
                    Text = "Select your industry:",
                    Topic = QuestionTopic.Industry,
                }, // 1
                new Question()
                {
                    CategoryId = 1,
                    Number = 2,
                    Type = QuestionType.Dropdown,
                    Topic = QuestionTopic.IndustrySize,
                    Text = "What is the size of your industry?",
                }, // 2
                new Question()
                {
                    CategoryId = 1,
                    Number = 3,
                    Type = QuestionType.Dropdown,
                    Text = "What is your post in the company?",
                    Topic = QuestionTopic.CompanyPosition,
                }, // 3
                new Question()
                {
                    CategoryId = 3,
                    Number = 4,
                    Text = "To what extent do you ensure that the data used to train your AI models considers diverse perspectives and avoid unfair outcomes for different user groups?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 4
                new Question()
                {
                    CategoryId = 3,
                    Number = 5,
                    Text = "How well do you continuously monitor and assess the performance of your AI systems for potential discrepancies and discriminatory patterns?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 5
                new Question()
                {
                    CategoryId = 3,
                    Number = 6,
                    Text = "To what extent can you explain how your AI models handle sensitive attributes and protected characteristics (eg., race, gender) to avoid making decisions based on such attributes and promote equitable outcomes?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 6
                new Question()
                {
                    CategoryId = 3,
                    Number = 7,
                    Text = "To what extent do you involve a variety of stakeholders, including those from underrepresented communities, in the development and testing of your AI systems to address potential fairness concerns?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 7
                new Question()
                {
                    CategoryId = 3,
                    Number = 8,
                    Text = "To what extent do you take steps to rectify and improve the fairness of your AI applications in case of unintended disparities, while maintaining their overall performance and accuracy?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 8
                new Question()
                {
                    CategoryId = 4,
                    Number = 9,
                    Text = "To what extent does your organization ensure that personal data collected by your AI systems is handled responsibly and in compliance with relevant privacy regulations?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 9
                new Question()
                {
                    CategoryId = 4,
                    Number = 10,
                    Text = "How well can you describe the security measures in place to safeguard sensitive user information from unauthorized access or data breaches?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 10
                new Question()
                {
                    CategoryId = 4,
                    Number = 11,
                    Text = "To what extent does your organization protect user confidentiality and ensure that personal data collected by your AI systems is used only for its intended purpose, without compromising individual privacy?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 11
                new Question()
                {
                    CategoryId = 4,
                    Number = 12,
                    Text = "How effectively does your organization enable users to control and manage their data, including the option to opt-out or delete their information if they choose to do so?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 12
                new Question()
                {
                    CategoryId = 4,
                    Number = 13,
                    Text = "To what extent are there procedures in place to regularly audit and review the data handling practices of your AI systems to ensure ongoing compliance with privacy and data protection standards?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 13
                new Question()
                {
                    CategoryId = 10,
                    Number = 14,
                    Text = "To what extent does your organization ensure that the decisions made by AI systems are transparent and can be easily understood by relevant stakeholders, including users and regulatory authorities?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 14
                new Question()
                {
                    CategoryId = 10,
                    Number = 15,
                    Text = "How well does your organization take steps to provide clear explanations for the outcomes generated by AI models, especially in critical use cases  where transparency is essential for building trust and accountability?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 15
                new Question()
                {
                    CategoryId = 10,
                    Number = 16,
                    Text = "To what extent does your organization involve users and stakeholders in the decision-making process of AI systems  to ensure that their concerns and requirements for transparency are considered?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 16
                new Question()
                {
                    CategoryId = 7,
                    Number = 17,
                    Text = "To what extent does your organization ensure that AI systems are designed to work collaboratively with human users and respect their autonomy in decision-making processes?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 17
                new Question()
                {
                    CategoryId = 7,
                    Number = 18,
                    Text = "How well does your organization implement measures to provide human oversight and control over AI-driven systems, especially in critical applications that could significantly impact individuals'' lives or society?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 18
                new Question()
                {
                    CategoryId = 7,
                    Number = 19,
                    Text = "To what extent does your organization address concerns about AI systems making decisions without human intervention, ensuring that human values and ethical considerations are upheld in the decision-making process? ",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 19
                new Question()
                {
                    CategoryId = 7,
                    Number = 20,
                    Text = "How well does your organization take steps to ensure that AI technologies do not replace human agency but rather augment human capabilities and decision-making processes?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 20
                new Question()
                {
                    CategoryId = 7,
                    Number = 21,
                    Text = "To what extent does your organization promote ethical AI design to prioritize human safety and well-being, avoiding scenarios where AI systems operate with high autonomy and limited human control in sensitive domains?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 21
                new Question()
                {
                    CategoryId = 5,
                    Number = 22,
                    Text = "To what extent does your organization ensure clear assignment of responsibility for AI system development, deployment, and outcomes, both within the organization and with external stakeholders?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 22
                new Question()
                {
                    CategoryId = 5,
                    Number = 23,
                    Text = "How well does your organization have measures in place to track, document and audit the decision-making process of AI systems, ensuring accountability for the results produced?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 23
                new Question()
                {
                    CategoryId = 5,
                    Number = 24,
                    Text = "To what extent does your organization address potential biases or unintended consequences in AI algorithms, and take steps to rectify and learn from any negative impacts?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 24
                new Question()
                {
                    CategoryId = 5,
                    Number = 25,
                    Text = "How well does your organization have mechanisms to handle disputes or complaints arising from AI-driven decisions, and provide affected individuals with avenues for recourse or redress?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 25
                new Question()
                {
                    CategoryId = 5,
                    Number = 26,
                    Text = "To what extent does your organization promote a culture of responsibility and ethical behaviour in AI development teams, encouraging transparency and open communication about challenges and potential risks?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 26
                new Question()
                {
                    CategoryId = 8,
                    Number = 27,
                    Text = "To what extent does your organization assess the potential effects of AI-driven technologies on individuals and communities and take steps to address any negative consequences on a broader scale?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 27
                new Question()
                {
                    CategoryId = 8,
                    Number = 28,
                    Text = "How well does your organization have mechanisms in place (e.g. a citizen advisory board) to continually monitor and assess the real-world impact of AI systems on individuals and communities, and utilize this feedback to improve responsible AI deployment?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 28
                new Question()
                {
                    CategoryId = 9,
                    Number = 29,
                    Text = "To what extent does your organization test and validate AI models to ensure their robustness and resistance to errors, adversarial attacks, or unexpected inputs?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 29
                new Question()
                {
                    CategoryId = 9,
                    Number = 30,
                    Text = "Please rate the extent to which your organization takes steps to identify and address potential vulnerabilities in AI systems, particularly in safety-critical applications.",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 30
                new Question()
                {
                    CategoryId = 9,
                    Number = 31,
                    Text = "How well does your organization ensure that AI systems generalize well to new, unseen data and maintain high accuracy in real-world scenarios?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 31
                new Question()
                {
                    CategoryId = 9,
                    Number = 32,
                    Text = "How frequently does your organization have measures in place  to continuously monitor and evaluate AI models in real-time, detecting any performance degradation or potential safety issues?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 32
                new Question()
                {
                    CategoryId = 9,
                    Number = 33,
                    Text = "To what extent does your organization ensure that AI-driven technologies comply with safety standards and regulations, especially in high-risk domains?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 33
                new Question()
                {
                    CategoryId = 6,
                    Number = 34,
                    Text = "To what extent does your organization ensure that AI models are designed with interpretability in mind, allowing for a clear understanding of the model''s decision-making process?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 34
                new Question()
                {
                    CategoryId = 6,
                    Number = 35,
                    Text = "Please rate the techniques or approaches used by your organization to make the internal workings of the AI model transparent and comprehensible to stakeholders.",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 35
                new Question()
                {
                    CategoryId = 6,
                    Number = 36,
                    Text = "How well does your organization provide insights into how the AI system generalizes from training data to make predictions on new data?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 36
                new Question()
                {
                    CategoryId = 6,
                    Number = 37,
                    Text = "To what extent does your organization address the trade-off between model complexity and interpretability to ensure that the AI system strikes an appropriate balance between accuracy and understandability?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 37
                new Question()
                {
                    CategoryId = 6,
                    Number = 38,
                    Text = "How frequently does your organization involve domain experts and end-users in the interpretability process to ensure that the explanations provided by the AI system align with their expectations and needs?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 38
                new Question()
                {
                    CategoryId = 2,
                    Number = 39,
                    Text = "To what extent does your organization measure and ensure the accuracy of AI models in real-world scenarios?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 39
                new Question()
                {
                    CategoryId = 2,
                    Number = 40,
                    Text = "Please rate the extent to which your organization validates the accuracy of the AI system against relevant test data and its performance on unseen data.",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 40
                new Question()
                {
                    CategoryId = 2,
                    Number = 41,
                    Text = "How well-prepared is your organization in addressing potential challenges with accuracy,  particularly when the AI encounters new or unexpected data?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 41
                new Question()
                {
                    CategoryId = 2,
                    Number = 42,
                    Text = "How frequently does your organization maintain accuracy when dealing with complex and dynamic real-world situations, and how often do you evaluate and update the AI model to ensure ongoing accuracy?",
                    Type = QuestionType.MCQ,
                    Options = new List<Option>()
                    {
                        new Option() { Text = "Not at all", Weight = 1 },
                        new Option() { Text = "To a small extent", Weight = 2 },
                        new Option() { Text = "Moderately", Weight = 3 },
                        new Option() { Text = "To a great extent", Weight = 4 },
                        new Option() { Text = "Completely", Weight = 5 }
                    },
                }, // 42
            });

            */
        }

    }
}
