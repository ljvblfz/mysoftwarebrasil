using System;

namespace OnPlaceMovel.Source.Teste {
	public interface ITesteController {
		bool ExecutarTeste(bool stopOnError, bool imprimirContas);
		bool ExecutarTeste();
		bool TestarMatricula(int seqMatricula);
	}
}
