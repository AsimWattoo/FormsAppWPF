using FormsApp.Core.Application;
using FormsApp.Core.View_Model.Base;
using FormsApp.Core.View_Model.PageViewModel;
using FormsApp.Pages;

namespace FormsApp.Converters
{
    public static class ApplicationPageHelpers
    {

        /// <summary>
        /// Converts an <see cref="ApplicationPages"/> to <see cref="BasePage"/>
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPages page, BaseViewModel viewModel = null)
        {
            switch (page)
            {
                case ApplicationPages.Questions:
                    return new QuestionsPage();
                case ApplicationPages.EditableQuestions:
                    return new EditableQuestionsPage();
                case ApplicationPages.Add_Edit_Form:
                    return new QuestionAddEditForm(viewModel as AddEditQuestionViewModel ?? new AddEditQuestionViewModel());
                case ApplicationPages.Recommendations:
                    return new RecommendationsPage();
                case ApplicationPages.Result:
                    return new ResultsPage(viewModel as ResultPageViewModel ?? new ResultPageViewModel());
                default:
                    return new DefaultPage();
            }
        }


        /// <summary>
        /// Converts a <see cref="BasePage"/> to <see cref="ApplicationPages"/>
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPages ToApplicationPage(this BasePage page)
        {
            return ApplicationPages.None;
        }

    }
}
