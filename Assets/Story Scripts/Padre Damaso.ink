INCLUDE Variables.ink

{ChapterState == 1:
    {DamasoState == 0: -> state0}
    {DamasoState == 1: -> state1}
}

{ChapterState == 2:
    {DamasoState == 0: -> state2}
}

{ChapterState == 3:
    {DamasoState == 0: -> state3}
    {DamasoState == 1: -> state4}
    {DamasoState == 2: -> state5}
}

// --- Chapter 1 ---
=== state0 ===
//Padre Damaso
Sa dalawampung taon kong pamamalagi at paninilbihan sa bayan ng San Diego, masasabi ko na walang kwenta ang mga Indio. Nasayang lang ang dalawampung taon na inilagi ko dito.#speaker:Padre Damaso #audio:PD_state0_0
Nagtiis ako na makisalamuha sa mga Indio at nagdildil ng kanin at saging ngunit anong isinukli nila sa akin? #audio:PD_state0_1
Mga iilang matanda at hermanos terceros lamang ang naghatid sa akin nang ako’y madestino sa ibang Parokya. Mga walang galang at modo! Mga walang utang na loob! #audio:PD_state0_2
//Padre Sibyla
Padre Damaso, maghinay-hinay lang po tayo. Nasa tahanan tayo ng isang Indio baka magdamdam si Kapitan Tiago.#speaker:Padre Sibyla  #audio:PD_state0_3
//Padre Damaso
Oo, totoo. Kung hindi lang talaga dahil sa isang Tenyente Heneral ay hindi ako madedestino sa ibang lugar.#speaker:Padre Damaso #audio:PD_state0_4
Biruin mo siya lang ang bukod tanging naniniwala na ang taong iyon ay inosente. Makasalanan ang taong iyon kaya dapat sumangguni muna sa akin kung nararapat bago ito ilibing. #audio:PD_state0_5
(Narinig ni Tenyente ang mga sinasabi ni Padre Damaso at hindi ito nakatiis na sumali sa usapan…) #speaker:Player #audio:null
~ DamasoState = 1
->END

=== state1 ===
//Padre Damaso
(Mukhang may pinag-uusapan sila ngunit hindi naman ito maunawaan… Mas mabuti siguro na hayaan na lang sila.)#speaker:Padre Damaso
->END

// --- Chapter 2 ---
=== state2 ===
(Agad ko nakilala si Padre Damaso na kanilang kura paroko sa kanilang bayan.) #speaker:Ibarra #audio:PD_state2_0
//Ibarra
Ipagpaumanhin kung ako’y magkamali, hindi po ba kayo si Padre Damaso; ang kura paroko sa aming bayan? #speaker:Ibarra #audio:PD_state2_1
Kayo rin po ay matalik na kaibigan ng aking ama, hindi po ba? #audio:PD_state2_2
//Damaso
Hindi ka nagkakamali ako nga si Padre Damaso ngunit ang relasyon namin ng iyong ama ay hindi kailanman naging matalik na magkaibigan. #speaker:Padre Damaso #audio:PD_state2_3
//Ibarra
Pasensya na po, Padre. #speaker:Ibarra #audio:PD_state2_4
{KasambahayState == 0:
    ~ talkToDamaso = 1
}
->END


// --- Chapter 3 ---
=== state3 ===
//Padre Damaso
Sa lahat ng mga inihandang pagkain sa akin dito sa Pilipinas, Tinola ang aking pinakapaborito! Napakasarap! #speaker:Padre Damaso #audio:PD_state3_0
->END

=== state4 ===
//Padre Damaso
Jusko! Ano ba naman ito? Bakit puro leeg at pakpak ng manok ang napunta sa aking tasa?#speaker:Padre Damaso #audio:PD_state4_0
(Sa sobrang inis ay humigop na lang ito ng sabaw habang dinudurog ang papaya ng may malakas na tunog na tila ba gusto iparinig #speaker:Ibarra #audio:PD_state4_1
sa mga kapwa bisita na hindi siya nagagalak sa mga nangyayari. Padabog niya rin binagsak ang kubyertos sa gilid ng kanyang pinggan.) #audio:PD_state4_2
{LarujaState == 0: 
    ~ LarujaState = 1 
}
->END

=== state5 ===
//Padre Damaso
Hah! Isa kang hangal. Naririnig mo ba ang sinasabi mo iho? Bakit ka pa nagsayang ng pera para lamang mag-aral sa Europa kung hindi ka naman pala masisiyahan? #speaker:Padre Damaso #audio:PD_state5_0
Ang iyong mga napag-aralan ay alam din naman ng kahit sinong mag-aaral na tanungin mo sa ating bansa. #audio:PD_state5_1 
//Ibarra
* [Manahimik]//choices
    ->choice1
* [Patulan]//choices
    ->choice2



=== choice1 ===
...... #speaker:Ibarra #audio:null
//Ibarra
Kapitan Tiago at sa mga dumalo, kakabalik ko lang mula sa isang mahabang biyahe galing Europa. Maunawaan po sana ninyo ang kagustuhan kong lumisan agad.#audio:PD_choice1_1 
Pupunta pa ako ng San Diego sa makalawa para sa Todos Los Santos kaya’t may mga kailangan pa akong asikasuhin. #audio:PD_choice1_2 
//Kapitan Tiyago
Hindi mo na ba aantayin ang aking pinakamamahal na dalaga na si Maria Clara? Matagal ka nang inaantay ng aking anak. #speaker:Kapitan Tiyago #audio:PD_choice2_6
//Ibarra
Ipagpaumanhin po ninyo Kapitan ngunit mas importante po ang mga bagay na aking aasikasuhin. Ako po ay babawi sa susunod na pagkakataon. #speaker:Ibarra #audio:PD_choice1_4 
Iparating niyo na lang po ang aking pagbati kay Maria. Muchas gracias sa hapunan, Kapitan. #audio:PD_choice1_5 
//Kapitan Tiyago
Walang problema, Ibarra. Ipaparating ko sa aking bulaklak ang iyong pagbati. Gabayan ka ng Panginoon sa iyong paglalakbay. #speaker:Kapitan Tiyago #audio:PD_choice1_6 
(Nagpaalam din ako sa ibang mga bisita at tuluyan nang umalis.) #speaker:Ibarra #audio:PD_choice1_7 
~ showEndSign = 1
->END

=== choice2 ===
Nako, Senyores, hindi na talaga nagbago ang aming dating kura. Walang pinagbago ang pakikitungo nito sa akin noong ako’y bata pa.  #speaker:Ibarra #audio:PD_choice2_0
Aking naaalala ang pagdalaw ng kanyang reverencia sa aming tahanan at nakakasalo pa ang aking ama.#audio:PD_choice2_1
(Nagtinginan ang lahat kay Padre Damaso pagkatapos itong patulan ni Ibarra. Natahimik ito at biglang nataranta sa mga tingin ng mga tao.) #speaker:Mga Bisita #audio:PD_choice2_2
//Padre Damaso
Ipagpaumanhin mo Senor Ibarra kung may nasabi akong hindi kaaya-aya. #speaker:Padre Damaso #audio:PD_choice2_3
//Ibarra
Pasensya na po Kapitan at sa inyo mga Senyores, dahil ako po ay mauuna nang lumisan sa hapag na ito. #speaker:Ibarra #audio:PD_choice2_4
Malayo pa po aking nilakbay kaya sana po ay maunawaan niyo ang aking kagustuhan na lumisan. Ako’y uuwi ho sa San Diego dahil may mga bagay po akong dapat ayusin. #audio:PD_choice2_5
//Kapitan Tiyago
Hindi mo na ba aantayin ang aking pinakamamahal na dalaga na si Maria Clara? Matagal ka nang inaantay ng aking anak. #speaker:Kapitan Tiyago #audio:PD_choice2_6
//Ibarra
Pasensya na ho, Kapitan ngunit mas importante po ang mga bagay na aking aasikasuhin. Muchas gracias sa hapunan, Kapitan.  #speaker:Ibarra #audio:PD_choice2_7
//Kapitan Tiyago
Walang anuman, Ibarra. Gabayan ka sana ng Panginoon sa iyong paglalakbay.#speaker:Kapitan Tiyago #audio:PD_choice2_8
//Damaso
(Makikita sa mga mukha ni Padre Damaso ang kanyang matinding galit dahil siya ay napahiya sa mga bisita.)#speaker:Padre Damaso #audio:null
Ito ang sinasabi ko sa inyo! Nasa dugo na ng mga Indio na ang pagiging walang modo. Nag-aral lang sa Europa akala mo kung sino na, itinuturing na ang sarili na napakataas.  #audio:PD_choice2_9
~ showEndSign = 1
->END











