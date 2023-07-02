INCLUDE Variables.ink

{showEndSign == 0: -> Home}
{showEndSign == 1: -> EndChapter}

=== Home ===
Sigurado ka ba na gusto mo na lumisan? Hindi mo na maibabalik ang iyong nasimulan. #speaker:System
-> Choices

=== EndChapter ===
Dito nagtatapos ang kabanatang ito, gusto mo na bang tumigil sa paglaro? #speaker:System
-> Choices

=== Choices ===
    *[Oo]
        ~ endChapter = 1
        ->END
    *[Hindi]
        ~ endChapter = 0
        ->END
        
->END