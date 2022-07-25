using Bank.ApplicationCore.DTOs.Movement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.ApplicationCore.Interfaces
{
    public interface IMovementRepository
    {
        List<MovementResponse> GetMovements();

        List<ReporteResponse> GetMovements(DateTime date, int client);

        SingleMovementResponse GetMovementById(int movementId);

        void DeleteMovementById(int movementId);

        SingleMovementResponse CreateMovement(CreateMovementRequest request);

        SingleMovementResponse UpdateMovement(int movementId, UpdateMovementRequest request);
    }
}
