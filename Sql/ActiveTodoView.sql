create view Active_Todos as
select UUID , Title 
from cqrsexample.dbo.Todos 
where State = 0

