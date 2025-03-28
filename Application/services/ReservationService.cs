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
        
        var customer = await CustomerRepository.GetById(customerId); // Customer 1, Customer 2
        var session = await SessionRepository.GetById(sessionId); // Session 1
        var sala = await SalaRepository.GetById(session.SalaId); // Sala 1
        
        var seat = sala.getSeat(seatNumber); // Seat 1, Seat 2
        var seatReservation = await SeatReservationRepository.GetBySeatId(seat.Id); 
        
        seatReservation.Reserve(customer.Id);
        
        await SeatReservationRepository.Update(seatReservation);
    }
}