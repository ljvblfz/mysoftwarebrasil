namespace Strategos.DesignPatterns {
	/// <summary>
	/// Generic para fazer classes usando o designe pattern singleton
	/// </summary>
	/// <typeparam name="T">Classe na qual vai ser feita o singleton.</typeparam>
	public class Singleton<T> where T : new() {
		/// <summary>
		/// Usado para evitar problemas em aplicativos que usam mais de uma thread
		/// </summary>
		private static readonly object _padlock = new object();
		/// <summary>
		/// Objeto da classe T
		/// </summary>
		private static T _singleton;
		
		/// <summary>
		/// Retorna uma instãncia global do objeto. Somente de leitura.
		/// </summary>
		/// <remarks>
		/// Funcionamento:
		/// <list type="bullet">
		/// <item><description>Chama lock() em _padlock</description></item>
		///	<item><description>caso _singleton seja nulo cria um novo objeto do tipo <typeparamref name="T"/></description></item>
		///	<item><description>retorna _singleton</description></item>
		/// </list>
		/// </remarks>
		public static T Instancia {
			get {
				lock ( _padlock ) {
					if ( _singleton == null )
						_singleton = new T();
					return _singleton;
				}
			}
		}
	}
}
