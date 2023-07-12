
using CodingQuestions;
using System.Reflection;

var lastQuestionType = Assembly.GetExecutingAssembly().GetTypes()
    .Where(x => x.GetInterface(nameof(ICodingQuestion)) != null)
    .OrderBy(x => x.Name)
    .Last();
var lastQuestion = (ICodingQuestion)Activator.CreateInstance(lastQuestionType)!;
lastQuestion.Run();
