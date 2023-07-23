using CodingQuestions;
using System.Reflection;

var questionTypes = Assembly.GetExecutingAssembly().GetTypes()
    .Where(x => x.GetInterface(nameof(ICodingQuestion)) != null && !x.ContainsGenericParameters)
    .OrderBy(x => x.Name);
foreach (var questionType in questionTypes)
{
    var question = (ICodingQuestion)Activator.CreateInstance(questionType)!;
    question.Run();
}
