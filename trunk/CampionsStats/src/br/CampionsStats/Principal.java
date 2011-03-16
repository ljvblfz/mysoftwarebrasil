package br.CampionsStats;

import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URI;
import java.net.URISyntaxException;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import br.CampionsStats.R;
import View.Inicial;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;


public class Principal extends Activity {
	
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
    	
    	//TESTE DE BANCO DE DADOS
    	///RepositorioCarro carrosDB = new RepositorioCarro(this);
    	//Carro c = new Carro();
    	//c.setId(1);
    	//c.setAno("2011");
    	//c.setNome("teste");
    	//c.setPlaca("teste");
    	//carrosDB.inserir(c);
    	//List<Carro> lista = carrosDB.buscarCarroPorNome("");
		//ConsomeServico sev = new ConsomeServico();
		//sev.getWebService();
   	
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
    
    
    @Override
	public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_atualizar, menu);
        return true;
    }

    
    @Override
	public boolean onOptionsItemSelected(MenuItem item) {
        // Handle item selection
        switch (item.getItemId()) {
        case R.id.item01:
            atualiar();
            return true;
        case R.id.item02:
            atualizarCampionatos();
            return true;
        default:
            return true;
        }
    }

	private void atualizarCampionatos() {

		String[] paises = {"Italiano","Brasileirão"} ;
		TableLayout layout = createTable(paises);
        super.setContentView(layout);
	}


	private TableLayout createTable(String[] ligas)
	{
		// Cria um objeto table
        TableLayout layout = new TableLayout (this);
        layout.setLayoutParams( new TableLayout.LayoutParams(LayoutParams.FILL_PARENT,50) );
        layout.setPadding(1,1,1,1);
        TextView textoPrincipal = new TextView(this);
        textoPrincipal.setText("Selecione os campionatos que deseja Atualizar.");
        textoPrincipal.setLayoutParams(new LayoutParams(LayoutParams.FILL_PARENT,50));
        layout.addView(textoPrincipal);

        for (int f=0; f<ligas.length; f++) {
            TableRow tr = new TableRow(this);
        	CheckBox c = new CheckBox(this);
        	tr.addView(c, LayoutParams.FILL_PARENT,30);
        	TextView t = new TextView(this);
            t.setText(ligas[f].toString().toCharArray(), 0, ligas[f].toString().length());
            tr.addView(t, LayoutParams.FILL_PARENT,40);
            layout.addView(tr);
        } // for
        
        Button btn = new Button(this);
        LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT);
        lp.weight = 1.0f;
        btn.setText("Fechar");
        //btn.setOnClickListener((OnClickListener) this);
        layout.addView(btn,lp);
        return layout;
	}

	private void atualiar() {
		Intent myIntent = new Intent();
		myIntent.setClassName("View", "Inicial");
		startActivity(myIntent);
	}
	
    public void onClick(View view) {

    }

}