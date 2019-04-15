VAR trust = 0
VAR mistrust = 0

->hello


==hello==

Where is captain? Can not find captain!


*[Calm down!]
~trust++
Yes sir!

->calm

*[Dead, probably...]
~mistrust++
LIE, LIE!

->notcalm


==calm


*[What's happening?]
~trust++
Captain disappear a week ago! No can find!
->DONE


*[Come with me!]
~mistrust++
STRANGER DANGER!
->DONE

==notcalm

AHHHHHH!


*[What's happening?]
~trust++
Captain disappear a week ago! No can find! REEEE!
->DONE


*[Come with me!]
~mistrust++
STRANGER DANGER! REEEEEEEE!
->DONE
