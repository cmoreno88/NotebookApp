﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//the NotebookApp shared space is how all our classes are communicating
namespace NotebookApp {
    class NotebookLogger {

        private Notebook trackedNotebook;
        private bool logging = true;

        public NotebookLogger(Notebook trackedNotebook) {

            this.trackedNotebook = trackedNotebook;

            Attach();
            trackedNotebook.loggingToggled += ToggleLogging;
        }


        private void PrintAdded( string typeItemAdded ) {
            Console.WriteLine(typeItemAdded + " was added to the notebook.");
        }

        private void PrintDeleted( string idOfDeleted) {
            if (idOfDeleted != "") {
                Console.WriteLine("Item " + idOfDeleted + " was deleted from the notebook.");
            } else {
                Console.WriteLine("Everything was deleted from the notebook.");
            }
        }

        private void IncorrectCommand(string messageToPrint) {
            Console.WriteLine("Bad Command: " + messageToPrint);
        }

        //Runs when loggingToggled event is ran
        public void ToggleLogging(bool turnOn) {
            string output = "Logger already " + ((turnOn) ? "on" : "off") + ".";

            if (logging) {

                if (!turnOn) {
                    Detach();
                    logging = false;
                    output = "Logger turned off.";
                }

            } else {

                if (turnOn) {
                    Attach();
                    logging = true;
                    output = "Logger turned on.";
                }
            }
            Console.WriteLine(output);
        }

        private void Attach() {
            trackedNotebook.ItemAdded += PrintAdded;
            trackedNotebook.ItemRemoved += PrintDeleted;
            trackedNotebook.InputBadCommand += IncorrectCommand;
        }

        private void Detach() {
            trackedNotebook.ItemAdded -= PrintAdded;
            trackedNotebook.ItemRemoved -= PrintDeleted;
            trackedNotebook.InputBadCommand -= IncorrectCommand;
        }
    }
}
