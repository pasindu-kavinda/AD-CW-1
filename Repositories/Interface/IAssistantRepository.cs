using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Repositories.Interface
{
    interface IAssistantRepository
    {
        List<AssistantModel> GetAllAssistants();
        AssistantModel GetAssistantById(int id);
        bool AddAssistant(AssistantModel assistant);
        bool UpdateAssistant(AssistantModel assistant);
        bool DeleteAssistant(int id);
    }
}
