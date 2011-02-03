package br.hello2;

import android.view.View;
import android.widget.AdapterView;
import android.widget.Toast;
import android.widget.AdapterView.OnItemSelectedListener;

public class MyOnItemSelectedListener  implements OnItemSelectedListener {

    public void onItemSelected(AdapterView<?> parent,View view, int pos, long id) {
      Toast.makeText(parent.getContext(), "The planet is " +parent.getItemAtPosition(pos).toString(), Toast.LENGTH_LONG).show();
    }

    @SuppressWarnings("unchecked")
	public void onNothingSelected(AdapterView parent) {
      // Do nothing.
    }
}