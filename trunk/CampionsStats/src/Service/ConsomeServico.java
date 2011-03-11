package Service;

import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URI;
import java.net.URISyntaxException;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import org.apache.http.HttpEntity;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.w3c.dom.Document;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;
import android.app.Activity;
import android.util.Log;
 
/*
 * Class de conexão com o web service retorna um documento xml no formato DOM
 * 
 * @autor: Alexis Moura
 * @package: Service
 */
public class ConsomeServico extends Activity {
    	
	/*
	 * Metodo de conexão do webService
	 * 
	 * @param: String URL - endereço do web service
	 * @retunr: Document objeto DOM
	 */
	public Document getWebService(String URL) {
		
		//URL = "http://www.aragon.ws/soccerdb/export/liveupdateleagues.php";
	    HttpEntity response = null;
	    Document document = null;
		HttpClient httpClient = new DefaultHttpClient();
		
		  try
		  {
			// Realiza a conexão
		    HttpGet method = new HttpGet( new URI(URL) );
		    response =  httpClient.execute(method).getEntity();
		    
		    // Carrega o retorno no objeto DOM
		    document = getDocument(response);

		  } catch (IOException e) {
		    Log.e( "error", e.getMessage() );
		  } catch (URISyntaxException e) {
		    Log.e( "error", e.getMessage() );
		  }
		  return document;
	}
	
	/*
	 *  Metodo que carrega o retorno do web service no objeto DOM
	 *  
	 * @param: HttpEntity entity - objeto com o retorno do web service
	 * @retunr: Document objeto DOM
	 */
	private Document getDocument(HttpEntity entity)
	{
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = null;
		Document document = null;
		
		try {  
			db = dbf.newDocumentBuilder();
			
			// Carrega os dados se o objeot for nulo
			if(entity != null)
			{
	        	InputStreamReader input = new InputStreamReader(entity.getContent(),"UTF-8");
				document = db.parse(new InputSource(input));
			}
        } catch (IOException ex) {  
            ex.printStackTrace();  
        } catch (SAXException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ParserConfigurationException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return document;
	}
	
}
