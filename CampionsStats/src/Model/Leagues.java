package Model;

import java.util.ArrayList;
import java.util.List;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;


public class Leagues {
	
	private List<League> league = new ArrayList<League>();
	
	public Leagues()
	{
	}
	
	public void add(League entry) {
		league.add(entry);
	}
	
	public List<League> getContent() {
		return league;
	}
	
	public void changeLeagues(Document document)
	{
		NodeList list = document.getElementsByTagName("league");
		
		for ( int i= 0 ; i<list.getLength () ; i++ ){
          League leage = new League(); 
          Element element = (Element) list.item(i);
          String nameIs = element.getNodeName();
          if(nameIs.equals("league"))
          {
        	  leage.setId(element.getAttributes().item(0).getNodeValue());
        	  NodeList chidren = element.getChildNodes();
        	  leage.setCountry(chidren.item(0).getChildNodes().item(0).getNodeValue());
        	  leage.setName(chidren.item(1).getChildNodes().item(0).getNodeValue());
          }
          this.add(leage);
        }
	}
}
