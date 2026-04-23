
namespace Basic01;



using Microsoft.Extensions.AI;
using System.Text;


internal class Program
{
    static async Task Main( string[] args )
    {
        Console.WriteLine( "Hello, World!" );

        //new OpenAI.Chat.ChatClient( model: "mini", apiKey: "lm-studio" ); //, new OpenAI.OpenAIClientOptions { Endpoint = new Uri( "http://localhost:1234/v1" ) } );

        IChatClient client = new OpenAI.Chat.ChatClient( 
            
            credential: new System.ClientModel.ApiKeyCredential( "lm-studio" ), 
            model: "google/gemma-4-e4b", //"microsoft/phi-4-mini-reasoning", // "phi4-mini", 
            options: new OpenAI.OpenAIClientOptions { Endpoint = new Uri( "http://localhost:1234/v1" ), NetworkTimeout = TimeSpan.FromMinutes(30) }

        ).AsIChatClient();

        //IChatClient client = new OpenAI.OpenAIClient(
        //    new System.ClientModel.ApiKeyCredential( "lm-studio" ),
        //    new OpenAI.OpenAIClientOptions { Endpoint = new Uri( "http://localhost:1234/v1" ) }
        //).AsIChatClient( "phi4-mini" );
        //new OllamaChatClient( new Uri( "http://localhost:11434/" ), "phi4-mini" );

        // here we're building the prompt
        StringBuilder prompt = new StringBuilder();

        prompt.AppendLine( "hi!" );

        //prompt.AppendLine( "You will analyze the sentiment of the following product reviews. Each line is its own review. Output the sentiment of each review in a bulleted list including the original text and the sentiment, and then provide a generate sentiment of all reviews. " );
        //prompt.AppendLine( "I bought this product and it's amazing. I love it!" );
        //prompt.AppendLine( "This product is terrible. I hate it." );
        //prompt.AppendLine( "I'm not sure about this product. It's okay." );
        //prompt.AppendLine( "I found this product based on the other reviews. It worked for a bit, and then it didn't." );

        // send the prompt to the model and wait for the text completion
        var response = await client.GetResponseAsync( prompt.ToString() );

        Console.WriteLine( response.Text );


    }
}
