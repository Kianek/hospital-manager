using System;
using HospitalManager.Api.Beds;

namespace HospitalManager.Api.Patients
{
    public class PatientBedAssignment
    {
        public Patient Patient { get; set; }
        public int RoomNumber { get; set; }
        public Bed Bed { get; set; }

        public PatientBedAssignment(int roomNumber, Patient patient, Bed bed)
        {
            RoomNumber = roomNumber;
            Patient = patient;
            Bed = bed;
        }

        public PatientBedAssignment()
        {
        }
    }
}