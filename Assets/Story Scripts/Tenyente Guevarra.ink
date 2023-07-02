INCLUDE Variables.ink

{ChapterState == 1:
    {TenyenteState == 0: -> state0}
    {TenyenteState == 1: -> state1}
}

{ChapterState == 2:
    {TenyenteState == 0: -> state2}
}

{ChapterState == 3:
    {TenyenteState == 0: -> state3}
    {TenyenteState == 1: -> state4}    
}
// --- Chapter 1 --- 
=== state0 ===
//Tenyente Guevarra
(Masaya silang nagkukwentuhan at kita naman na naaaliw sila sa pagtitipon…) #speaker:Tenyente Guevarra
->END

=== state1 ===
//Tenyente Guevarra
Mawalang galang po Padre, sa pagkakaalam ko po ay wala po kayo noong araw na ililibing na ang taong iyon,kaya kanino po kami sasangguni? Kaya po ay aming inilibing na ang marangal at mabuting tao na iyon. #speaker:Tenyente Guevarra #audio:TG_state1_0
//Padre Damaso
Aba! Hindi niyo pa rin pinaalam sa akin na nailibing niyo na pala yung taong iyon. May atraso pa ang erehe na iyon at napakamakasalanan nito para ilibing ito. Hindi niyo lang naisip na may kura paroko kayo! #speaker:Padre Damaso #audio:TG_state1_1
//Tenyente Guevarra 
Una po sa lahat, ang sinasabi ninyong erehe ay inosente. Pangalawa kayo rin ho ang may kasalanan #speaker:Tenyente Guevarra #audio:TG_state1_3
kung bakit kayo nadestino dahil ipinahukay niyo ang pinagbibintangan niyong erehe dahil lang sa hindi pangungumpisal?  #audio:TG_state1_4
Hindi po ba kabuktutan ito at pang-aabuso sa kapangyarihan? Ang parusa na kayo ay ipalipat na ipinataw ng Kapitan Heneral ay nararapat lang. #audio:TG_state1_5
(Makikita sa mukha ni Padre Damaso na ito ay nagpupuyos na sa galit kaya ito ay sinubukang pakalmahin ni Padre Sibyla.)#speaker:Manlalaro #audio:null
(Maya’t maya ay biglang bumukas ang pintuan..)
~ StoryState = 1
->END

// --- Chapter 2 ---
=== state2 ===
//Tenyente Guevarra
Ikaw pala ang anak ni Don Rafael… Maligayang pagbabalik dito sa ating inang bayan. #speaker:Tenyente Guevarra #audio:TG_state2_0
//Ibarra
Ako nga po iyon Senior. #speaker:Ibarra #audio:TG_state2_1
//Tenyente Guevarra
Napakabuting tao ng iyong ama at nakikita ko rin iyon sa iyo. sana’y mapunta sayo ang kasiyahan na ipinagkait sa kanya. #speaker:Tenyente Guevarra #audio:TG_state2_2
//Ibarra
Sana nga po… #speaker:Ibarra #audio:TG_state2_3
{KasambahayState == 0:
    ~ talkToTenyente = 1
}
->END

//Chapter 3
=== state3 ===
(Tahimik lang ang Tenyente habang inaantay nitong ihanda ang pagkain… Ngunit parang tila masama ang tingin nito kay Padre Damaso.) #speaker:Tenyente Guevarra
->END

=== state4 ===
(Tahimik lang ang Tenyente habang hinihigop ang sabaw ng tinola.)  #speaker:Tenyente Guevarra
->END









