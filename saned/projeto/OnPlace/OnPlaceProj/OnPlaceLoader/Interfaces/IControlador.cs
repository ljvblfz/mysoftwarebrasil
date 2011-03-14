namespace OnPlaceLoader.Interfaces {
	interface IControlador {
		/// <summary>
		/// Estado atual do controlador
		/// </summary>
		OnPlaceLoader.Enumerations.EstadoControlador Estado { get; }
		
		/// <summary>
		/// Executa a tarefa para qual o controlador foi feito
		/// </summary>
		void Executar();
	}
}
