package BD;

import java.util.ArrayList;
import java.util.List;

import Model.Carro;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

public class RepositorioCarro {
	
    private SQLiteDatabase db;
    private static final String SCRIPT_DB_DELETE = "DROP TABLE IF EXISTS carros";
    private static final String SCRIPT_DB_CREATE = "create table carros (_id integer primary "+
											        "key autoincrement, nome text not null, "+
											        "placa text not null, ano text not null);";

    public RepositorioCarro (Context ctx){
    	SQLiteHelper dbHelper = new SQLiteHelper(ctx,"curso", 1, SCRIPT_DB_CREATE, SCRIPT_DB_DELETE);
    	db = dbHelper.getWritableDatabase();
    }

    public long inserir(Carro c){
        ContentValues cv = new ContentValues();
        cv.put("nome", c.getNome());
        cv.put("placa", c.getPlaca());
        cv.put("ano", c.getAno());
        return db.insert("carros", null, cv);
    }

    public long atualizar(Carro c){
        ContentValues cv = new ContentValues();
        cv.put("nome", c.getNome());
        cv.put("placa", c.getPlaca());
        cv.put("ano", c.getAno());
        return db.update("carros", cv, "_id = ?", 
            new String[]{ String.valueOf(c.getId())});
    }

    public int excluir(int id){
        return db.delete("carros", "_id = ?", 
            new String[]{ String.valueOf(id) });
    }

    public List<Carro> buscarCarroPorNome(String nome){
        List<Carro> lista = new ArrayList<Carro>();

        String[] columns = new String[]{
            "_id", "nome", "placa", "ano"};
        String[] args = new String[]{nome+"%"};

        Cursor c = db.query("carros", columns, 
            "nome like ?", args, null, null, "nome");

        c.moveToFirst();
        while(!c.isAfterLast()){
            Carro carro = fillCarro(c);
            lista.add(carro);
            c.moveToNext();
        }
        return lista;
    }

    private Carro fillCarro(Cursor c) {
        Carro carro = new Carro();
        carro.setId((int)c.getLong(0));
        carro.setNome(c.getString(1));
        carro.setPlaca(c.getString(2));
        carro.setAno(c.getString(3));
        return carro;
    }
}

