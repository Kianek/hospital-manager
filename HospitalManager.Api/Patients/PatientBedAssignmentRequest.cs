using System;

namespace HospitalManager.Api.Patients
{
    public class PatientBedAssignmentRequest
    {
        public string HospitalName { get; set; }
        public int RoomNumber { get; set; }
        public Guid PatientId { get; set; }
        public Guid BedId { get; set; }

        public PatientBedAssignmentRequest(string hospitalName, int roomNumber, Guid patientId, Guid bedId)
        {
            HospitalName = hospitalName;
            RoomNumber = roomNumber;
            PatientId = patientId;
            BedId = bedId;
        }

        public PatientBedAssignmentRequest()
        {
        }
    }
}