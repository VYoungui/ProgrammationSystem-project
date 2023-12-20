using System;

public class Simulation
{
    public int SimulationID { get; set; }
    public string NomSimulation { get; set; }
    public int NumeroSimulation { get; set; }
    public int DetailID { get; set; }
    public int LogID { get; set; }

    // Propriétés de navigation
    public DétailsSimulation DétailsSimulation { get; set; }
    public Logs Logs { get; set; }
}
