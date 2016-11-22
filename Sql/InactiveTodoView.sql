create view Inactive_Todos as
select UUID, Title 
from cqrsexample.dbo.Todos 
where State = 1
