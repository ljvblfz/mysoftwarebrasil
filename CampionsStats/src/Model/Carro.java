package Model;

	public class Carro {
	
		@SuppressWarnings("unused")
		private String tableName = "carro";
		private int idCarro;
		private String nome;
		private String placa;
		private String ano;
		
		public Carro() {
	
		}
	
		public void setId(int value) {
			this.idCarro = value;
		}
		public void setNome(String value) {
			this.nome = value;
		}
		public void setPlaca(String value) {
			this.placa = value;
		}
		public void setAno(String value) {
			this.ano = value;
		}
		public String getPlaca() {
			return this.placa;
		}
		public String getAno() {
			return this.ano;
		}
		public long getId() {
			return this.idCarro;
		}
		public String getNome() {
			return this.nome;
		}
	
	
	}
