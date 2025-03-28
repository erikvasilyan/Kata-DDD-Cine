using Domain.customer;
using Domain.repositories;
using Domain.seat;
using Domain.session;

namespace Application.services;

public class ReservationService
{
    private SalaRepository SalaRepository;
    private CustomerRepository CustomerRepository;
    private SessionRepository SessionRepository;
    private SeatReservationRepository SeatReservationRepository;

    // Different customers can reserve different seats at the same time +
    // Customer can't reserve more seats than available in the sala +
    // Customer can't reserve a seat that is already reserved +
    
    public async void reserveSeatForSession(string requestCustomerId, string requestSessionId, int requestSeatNumber)
    {
        var customerId = CustomerId.fromString(requestCustomerId);
        var sessionId = SessionId.fromString(requestSessionId); 
        var seatNumber = new SeatNumber(requestSeatNumber);
        
        var customer = await CustomerRepository.GetById(customerId);
        var session = await SessionRepository.GetById(sessionId);
        var sala = await SalaRepository.GetById(session.SalaId);
        
        var seat = sala.getSeat(seatNumber);
        var seatReservation = await SeatReservationRepository.GetBySeatId(seat.Id); 
        
        seatReservation.Reserve(customer.Id);
        
        await SeatReservationRepository.Update(seatReservation);
    }
}