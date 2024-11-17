using BandManager.Api.BLL.Utilities;
using BandManager.Api.Resources.Enums;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.BLL.Services;

public class AgentService : DirectDbService<Agent>
{
    IAgentRepository _agentRepository;

    public AgentService(IDirectDbRepository<Agent> repository) : base(repository)
    {
        _agentRepository = (IAgentRepository)repository;
    }

    public void ValidateAndAdd(Agent agent)
    {
        bool agentExists = _agentRepository.GetWhere(a => a.Name == agent.Name).Any();

        if(!EmailValidator.IsValidEmail(agent.Email))
            throw new ArgumentException("Email is invalid");
        if(agent.PhoneNumber.Length < 8)
            throw new ArgumentException("Phone number is invalid");
        if (agent.Name.Length < 2)
            throw new ArgumentException("Agent name is too short");
        if (agentExists)
            throw new InvalidOperationException("Agent already exists");

        _agentRepository.Create(agent);
    }

    /// <summary>
    /// Removes an agent from the database by id
    /// </summary>
    /// <param name="id">The id of the agent to remove</param>
    /// <returns></returns>
    public void DeleteAgent(int id)
    {
        Agent agent = _agentRepository.GetById(id);
        if (agent == null)
            throw new KeyNotFoundException("Agent not found");

        _agentRepository.Delete(agent);
    }

    /// <summary>
    /// Deletes all agents that have no bookings,
    /// not sure if this function is needed, but just in case
    /// I get paid per line of code :D jk, I don't get paid at all
    /// </summary>
    /// <exception cref="Exception">No agents found</exception>
    /// <returns></returns>
    public void DeleteUnusedAgents()
    {
        List<Agent> agents = _agentRepository.GetAll().ToList();
        if (agents.Count == 0)
            throw new KeyNotFoundException("No agents found");
        foreach (Agent agent in agents)
        {
            if (agent.Bookings.Count == 0)
                _agentRepository.Delete(agent);
        }
    }
}