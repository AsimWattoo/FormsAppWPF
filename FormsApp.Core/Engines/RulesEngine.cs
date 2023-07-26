using FormsApp.Core.Models;
using FormsApp.Core.View_Model.ControlViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FormsApp.Core.Engines
{
    public static class RulesEngine
    {

        #region Public Methods

        /// <summary>
        /// Generates the expression to find the result
        /// </summary>
        /// <returns></returns>
        public static Func<Recommendation, double, int, string> GenerateExpression()
        {
            // if recommendation.QuestionId == id then
            //  if value >= recommendation.MinValue && value <= recommendation.MaxValue
            //  then return recommendation.Text
            //  else return ""
            // else return ""
            //Getting the properties to use
            Type type = typeof(Recommendation);
            PropertyInfo questionIdProperty = type.GetProperty(nameof(Recommendation.QuestionId));
            PropertyInfo maxValueProperty = type.GetProperty(nameof(Recommendation.MaxValue));
            PropertyInfo minValueProperty = type.GetProperty(nameof(Recommendation.MinValue));
            PropertyInfo recommendationTextProperty = type.GetProperty(nameof(Recommendation.RecommendationText));

            //Creating the parameter for the recommendation type
            ParameterExpression recommendationParameterExpression = Expression.Parameter(typeof(Recommendation), "rec");
            ParameterExpression valueParameterExpression = Expression.Parameter(typeof(double), "value");
            ParameterExpression questionIdParameterExpression = Expression.Parameter(typeof(int), "questionId");
            //Creating Member Access
            MemberExpression questionId = Expression.Property(recommendationParameterExpression, questionIdProperty);
            MemberExpression maxValue = Expression.Property(recommendationParameterExpression, maxValueProperty);
            MemberExpression minValue = Expression.Property(recommendationParameterExpression, minValueProperty);

            //Constant Expressions
            ConstantExpression constExpression = Expression.Constant(string.Empty, typeof(string));

            //Creating the Inner Condition
            BinaryExpression firstInnerCondition = Expression.MakeBinary(ExpressionType.GreaterThanOrEqual, valueParameterExpression, minValue);
            BinaryExpression secondInnerCondition = Expression.MakeBinary(ExpressionType.LessThanOrEqual, valueParameterExpression, maxValue);
            BinaryExpression innerCondition = Expression.And(firstInnerCondition, secondInnerCondition);

            //Defining the inner expression
            MemberExpression firstInnerExpression = Expression.MakeMemberAccess(recommendationParameterExpression, recommendationTextProperty);

            //Defining the inner block
            Expression innerBlock = Expression.Condition(innerCondition, firstInnerExpression, constExpression);

            //Defining the outer condition
            BinaryExpression outerCondition = Expression.MakeBinary(ExpressionType.Equal, questionId, questionIdParameterExpression);

            //Defining the outer block
            Expression outerBlock = Expression.Condition(outerCondition, innerBlock, constExpression);
            

            Expression<Func<Recommendation, double, int, string>> lambdaExp = Expression.Lambda<Func<Recommendation, double, int, string>>(outerBlock, recommendationParameterExpression, valueParameterExpression, questionIdParameterExpression);

            return lambdaExp.Compile();
        }

        /// <summary>
        /// Finds the appropriate recommendations based on given recommendations, value and the question id
        /// </summary>
        /// <param name="recommendations"></param>
        /// <param name="value"></param>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public static List<string> GenerateRecommendations(List<Recommendation> recommendations, double value, int questionId)
        {
            Func<Recommendation, double, int, string> expression = GenerateExpression();
            List<string> results = new List<string>();
            foreach(Recommendation rec in recommendations)
            {
                string recommendation = expression.Invoke(rec, value, questionId);
                if(!string.IsNullOrEmpty(recommendation))
                {
                    results.Add(recommendation);
                }
            }
            return results;
        }

        /// <summary>
        /// Generates recommendations for the given set of questions
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="recommendations"></param>
        /// <returns></returns>
        public static List<QuestionWiseRecommendations> GenerateRecommendations(List<QuestionViewModel> questions, List<Recommendation> recommendations)
        {
            List<QuestionWiseRecommendations> results = new List<QuestionWiseRecommendations>();
            foreach(QuestionViewModel question in questions)
            {
                double value = question.Options.Where(t => t.Number == question.SelectedOption).First().Weight;
                QuestionWiseRecommendations recommendation = new QuestionWiseRecommendations();
                recommendation.QuestionId = question.Number;
                recommendation.Result = value;
                recommendation.Text = question.Text;
                recommendation.Recommendations = GenerateRecommendations(recommendations, value, question.Number);
                if(recommendation.Recommendations.Count > 0)
                {
                    results.Add(recommendation);
                }
            }
            return results;
        }

        #endregion

    }
}
