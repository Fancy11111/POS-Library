using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Networking
{
    public class Network<T> : IDisposable where T : class
    {
        public TcpClient Client { get; set; }
        public StreamReader Reader { get; set; }
        public StreamWriter Writer { get; set; }
        private XmlSerializer xml = new XmlSerializer(typeof(T));

        #region Receive/Send Generic
        public Network(TcpClient client)
        {
            Client = client;
            Reader = new StreamReader(client.GetStream());
            Writer = new StreamWriter(client.GetStream());
        }

        public void SendObject(T obj)
        {
            using(StringWriter sw = new StringWriter())
            {
                xml.Serialize(sw, obj);
                Writer.WriteLine(sw);
                Writer.Flush();
            }
        }

        public T ReceiveObject()
        {
            try
            {
                string line, str = "", endTag = $"<{typeof(T).Name}/>";

                while((line = Reader.ReadLine()) != endTag)
                {
                    str += line;
                }
                str += endTag;

                using(StringReader sr = new StringReader(str))
                {
                    return xml.Deserialize(sr) as T;
                }
            }
            catch (ObjectDisposedException)
            {
                return null;
            }
        }

        #region Send/Receive Strings
        // To just send a string without serialization
        public void SendString(string data) {
            using (StringWriter sw = new StringWriter())
            {
                sw.Write(data);
                Writer.WriteLine(sw);
                Writer.Flush();
            }
        }

        public string ReceiveString()
        {
            try
            {
                string line, str = "";
                while ((line = Reader.ReadLine()) != "</Message>") // Change end tag to name of class
                    str += line;

                str += "</Message>";

                return str;
            }
            catch (ObjectDisposedException)
            {
                return null;
            }
        }
        #endregion

        #region IDisposable Support
        // Not really needed

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Writer?.Close();
                    Reader?.Close();
                    Client?.Close();
                }

                disposedValue = true;
            }
        }
        
        ~Network() {
           Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
