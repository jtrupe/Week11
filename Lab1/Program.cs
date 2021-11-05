/// Week 11 Lab 1
///
/// @author: Julian Trupe
/// Date:  November 4, 2021
///
/// Problem Statement: Create a Document class with text property, Email and File derived classes
//
/// Overall Plan:
/// 1) Create Document class with text property, getter/setter
/// 2) Create derived Email class with additional sender, recipient, title properties, getters/setters, overridden ToString() method
/// 3) Create derived File (from Document) class with additional pathname property, getter/setter, overridden ToString() method
/// 4) Create 2 Email and File objects in the main method and test classes
/// 5) Pass email and file to ContainsKeyoword method, to validate it works


using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Below we will test some classes");
            Email email1 = new Email();
            Email email2 = new Email("hello world", "Julian", "Grace", "greeting");
            File file1 = new File();
            File file2 = new File("_home", "blah blah blah");
            Console.WriteLine(email1.ToString());
            Console.WriteLine(email2.ToString());
            Console.WriteLine(file1.ToString());
            Console.WriteLine(file2.ToString());

            Console.WriteLine(ContainsKeyword(email2, "hello"));
            Console.WriteLine(ContainsKeyword(file2, "blah"));
        }

        public static bool ContainsKeyword(Document docObject, string keyword)
        {
            if (docObject.ToString().IndexOf(keyword, 0) >= 0)
            {
                return true;
            }
            return false;
        }
    }

    class Document
    {
        protected string text;

        public Document()
        {
            SetText("sample text");
        }

        public Document(string txt)
        {
            SetText(txt);
        }
        
        public void SetText(string txt)
        {
            text = txt;
        }
        public string ToString()
        {
            return text;
        }
    }

    class Email : Document
    {
        private string sender;
        private string recipient;
        private string title;

        public Email()
        {
            SetSender("John Doe");
            SetRecipient("Jane Doe");
            SetTitle("Subject");
            SetText("sample text");
        }
        public Email(string txt, string sent, string received, string title)
        {
            SetText(txt);
            SetSender(sent);
            SetRecipient(received);
            SetTitle(title);
        }
        
        public string GetSender()
        {
            return sender;
        }
        public void SetSender(string sent)
        {
            sender = sent;
        }
        public string GetRecipient()
        {
            return recipient;
        }
        public void SetRecipient(string received)
        {
            recipient = received;
        }
        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string txt)
        {
            title = txt;
        }
        public string ToString()
        {
            return GetSender() + GetRecipient() + GetTitle() + text;
        }
    }

    class File : Document
    {
        private string pathname;

        public File()
        {
            SetPath("_default");
            SetText("sample text");
        }
        public File(string path, string txt)
        {
            SetPath(path);
            SetText(txt);
        }

        public void SetPath(string path)
        {
            pathname = path;
        }
        public string GetPath()
        {
            return pathname;
        }

        public string ToString()
        {
            return GetPath() + text;
        }
    }
}
