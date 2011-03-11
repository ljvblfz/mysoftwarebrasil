package Model;

public class Id {
	private String id = "0";
	
	public Id() {
		System.out.println("chamou construtor default...");
    }
	
	public Id(String value) {
	  this.id = value;
    }
	
	// implementar readresolve fazer que o construtor default
    // passe a ser chamado na desserialização
    private Id readresolve() {
          return this;
    }
}
