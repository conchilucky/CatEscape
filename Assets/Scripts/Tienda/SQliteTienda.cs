using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;//Librería añadida para trabajar con la DB
using System.IO;//Librería para poder abrir archivos
using Mono.Data.Sqlite;//Librería para trabajar con SQLite
using UnityEngine.UI; //Para usar el Canvas de Unity
using System; //Para por ejemplo mandar mensajes del sistema (error/aviso...)

public class SQliteTienda : MonoBehaviour
{
    #region Variables
    public static string color;
    public static string colorEquipado;
    public ManageTienda manageTienda;

    int estaComprada;
    string rutaDB;
    string strConexion;
    string DBFileName = "GuardadoTienda.db";
    
    //Referencia que necesitamos para poder crear una conexión 
    IDbConnection dbConnection;
    //Referencia que necesitamos para poder ejecutar comandos 
    IDbCommand dbCommand;
    //Referencia que necesitamos para leer datos
    IDataReader reader;
    #endregion
    void Start()
    {
        AbrirDB();
        ComandoWhere("*", "Tienda", "Equipado", "=", "1");
        ComandoWhereDos("*", "Tienda", "Comprado", "=", "1");
        CerrarDB();
    }
    void AbrirDB()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            rutaDB = Application.dataPath + "/StreamingAssets/" + DBFileName;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            rutaDB = Application.persistentDataPath + "/" + DBFileName;
            if (!File.Exists(rutaDB))
            {
                WWW loadDB = new WWW("jar;file://" + Application.dataPath + DBFileName);
                while (!loadDB.isDone)
                {

                }
                File.WriteAllBytes(rutaDB, loadDB.bytes);
            }
        }

        strConexion = "URI=file:" + rutaDB;
        dbConnection = new SqliteConnection(strConexion);
        dbConnection.Open();
    }
    void CerrarDB()
    {
        // Cerrar las conexiones
        if(reader != null)
        {
            reader.Close();
            reader = null;
        }
        
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
    void ComandoSelect(string item, string tabla)
    {
        // Crear la consulta
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "SELECT " + item + " FROM " + tabla;
        dbCommand.CommandText = sqlQuery;

        // Leer la base de datos
        reader = dbCommand.ExecuteReader();
        while (reader.Read())
        {
            try
            {
                Debug.Log(reader.GetString(0) + " - " + reader.GetInt32(1) + " - " + reader.GetInt32(2) + " - " + reader.GetInt32(3));
                color = reader.GetString(0);
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }
    void ComandoWhere(string item, string tabla, string campo, string comparador, string dato)
    {
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "select " + item + " from " + tabla + " where " + campo + " " + comparador + " " + dato;
        dbCommand.CommandText = sqlQuery;
        reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                colorEquipado = reader.GetString(0);
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }
    void ComandoWhereDos(string item, string tabla, string campo, string comparador, string dato)
    {
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "select " + item + " from " + tabla + " where " + campo + " " + comparador + " " + dato;
        dbCommand.CommandText = sqlQuery;

        reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetString(i) == "Blanco" )
                    {
                        manageTienda.tieneLaSkinBlancaComprada = true;
                    }
                    if (reader.GetString(i) == "Negro")
                    {
                        manageTienda.tieneLaSkinNegraComprada = true;
                    }
                    if (reader.GetString(i) == "Siames")
                    {
                        manageTienda.tieneLaSkinSiamesComprada = true;
                    }
                    if (reader.GetString(i) == "Rayas")
                    {
                        manageTienda.tieneLaSkinRayasComprada = true;
                    }
                    if (reader.GetString(i) == "Michi")
                    {
                        manageTienda.tieneLaSkinMichiComprada = true;
                    }
                    if (reader.GetString(i) == "Gris")
                    {
                        manageTienda.tieneLaSkinGrisComprada = true;
                    }
                }
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }
    void UPDATE(string color)
    {
        dbCommand = dbConnection.CreateCommand();

        string sqlQuery = $"UPDATE Tienda SET Equipado = 1 WHERE Colores = \"{colorEquipado}\"";

        dbCommand.CommandText = sqlQuery;

        reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + "-" + reader.GetString(3));
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }
    void Desequipar()
    {
        dbCommand = dbConnection.CreateCommand();

        string sqlQuery = $"UPDATE Tienda SET Equipado = 0 WHERE Equipado = 1";

        dbCommand.CommandText = sqlQuery;

        reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + "-" + reader.GetString(3));
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }
    void Comprado()
    {
        dbCommand = dbConnection.CreateCommand();

        string sqlQuery = $"UPDATE Tienda SET Comprado = 1 WHERE Colores = \"{color}\"";

        dbCommand.CommandText = sqlQuery;

        reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + "-" + reader.GetString(3));
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }

    }
    public void Boton()
    {
        AbrirDB();
        Desequipar();
        UPDATE(color);
        ComandoSelect("*", "Tienda");
        CerrarDB();
    }
    public void BotonComprar()
    {
        AbrirDB();
        Comprado();
        ComandoSelect("*", "Tienda");
        CerrarDB();
    }
}
