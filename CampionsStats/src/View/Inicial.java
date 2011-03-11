/**
 * 
 */
package View;

import br.CampionsStats.R;
import android.app.Activity;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

/**
 * @author Alexis
 *
 */
public class Inicial  extends Activity{

    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
    	
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        
        // Combo de jogos
        Spinner spinner = (Spinner) findViewById(R.id.spinner_jogos);
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(
                this, R.array.jogos_array, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner.setAdapter(adapter);
        
        // Combo de rodadas
        Spinner spinner2 = (Spinner) findViewById(R.id.spinner_rodada);
        ArrayAdapter<CharSequence> adapterRodada = ArrayAdapter.createFromResource(
                this, R.array.rodada_array, android.R.layout.simple_spinner_item);
        adapterRodada.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner2.setAdapter(adapterRodada);
    }
}
