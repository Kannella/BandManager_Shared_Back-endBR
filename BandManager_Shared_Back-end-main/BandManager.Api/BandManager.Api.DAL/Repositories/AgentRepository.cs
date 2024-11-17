using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.DAL.Repositories;

public class AgentRepository(BandManagerContext context) : DirectDbRepository<Agent>(context), IAgentRepository
{

}