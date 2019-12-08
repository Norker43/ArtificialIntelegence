;;****************
;;* DEFFUNCTIONS *
;;****************

(deffunction ask-question (?question $?allowed-values)
   (printout t ?question)
   (bind ?answer (read))
   (if (lexemep ?answer) 
       then (bind ?answer (lowcase ?answer)))
   (while (not (member$ ?answer ?allowed-values)) do
      (printout t ?question)
      (bind ?answer (read))
      (if (lexemep ?answer)
          then (bind ?answer (lowcase ?answer))))
   ?answer)

(deffunction yes-or-no-p (?question)
   (bind ?response (ask-question ?question yes no y n))
   (if (or (eq ?response yes) (eq ?response y))
       then yes 
       else no))

;;;***************
;;;* QUERY RULES *
;;;***************

(defrule determine-story-games ""
   (not (story-games ?))
   (not (finalAnswer ?))
   =>
   (assert (story-games (yes-or-no-p "Do you want to play in story games? (yes/no) "))))
   
(defrule determine-game-mode ""
   (not(game-mode ?))
   (story-games no)
   (not (finalAnswer ?))
   =>
   (assert (game-mode (yes-or-no-p "Would you like to play cooperative games? (yes/no) "))))
   
(defrule determine-dancing ""
   (not(dancing ?))
   (not (finalAnswer ?))
   =>
   (assert (dancing (yes-or-no-p "Would you like to dance during the games? (yes/no) "))))
   
(defrule determine-listening-music ""
   (not(listening-music ?))
   (dancing no)
   (not (finalAnswer ?))
   =>
   (assert (listening-music (yes-or-no-p "Do you want to listen music during the games? (yes/no) "))))
 
(defrule determine-timing ""
   (not (finalAnswer ?))
   =>
   (assert (timing (ask-question "How much time do you plan to spend in a VR-club (15m, 30m, 60m+) ? " 15 30 60))))
   
(defrule determine-friends ""
   (not(friends ?))
   (dancing no)
   (listening-music no)
   (not (finalAnswer ?))
   =>
   (assert (friends (yes-or-no-p "Have you come with friends? (yes/no) "))))
   
(defrule determine-vest-problem ""
   (or (story-games no)
   (game-mode no))
   (not(vest-problem ?))
   (not (finalAnswer ?))
   =>
   (assert (vest-problem (yes-or-no-p "Do you have a problem with the vestibular apparatus? (yes/no) "))))
   
(defrule determine-violence ""
   (not(violence ?))
   (vest-problem no)
   (not (finalAnswer ?))
   =>
   (assert (violence (yes-or-no-p "Do you want to see violence? (yes/no) "))))
   
;;;****************
;;;* dia RULES *
;;;***
(defrule yes-timing-rest-rule ""
   (and(timing ?timing)
   (test(> ?timing 30)))
   =>
   (assert (timing-rest yes)))
   
(defrule no-timing-rest-rule ""
   (and(timing ?timing)
   (test(<= ?timing 30)))
   =>
   (assert (timing-rest no)))
   
(defrule story-coop ""
   (or (story-games yes)
		  (game-mode yes))
   (not (finalAnswer ?))
   =>
   (assert (story-coop yes)))
   
(defrule determine-story-coop ""
   (story-games no)
   (game-mode no)
   (not (finalAnswer ?))
   =>
   (assert (story-coop no)))
   
(defrule rhythm-games ""
	(or (dancing yes)
	(listening-music yes)
	(friends yes))
	(not (finalAnswer ?))
	=>
	(assert (rhythm-games yes)))
   
(defrule determine-rhythm-games ""
	(dancing no)
	(listening-music no)
	(friends no)
	(not (finalAnswer ?))
	=>
	(assert (rhythm-games no)))
   
(defrule low-time ""
	(story-games yes)
	(rhythm-games yes)
	(not (finalAnswer ?))
    =>
	(assert (low-time yes)))
   
(defrule determine-low-time ""
	(rhythm-games no)
	(story-games no)
	(not (finalAnswer ?))
	=>
	(assert (low-time no)))
   
(defrule survival-games ""
	(or (vest-problem yes)
	(violence yes))
	(not (finalAnswer ?))
	=>
	(assert (survival-games yes)))
   
(defrule determine-survival-games ""
	(vest-problem no)
	(violence no)
	(not (finalAnswer ?))
	=>
	(assert (survival-games no)))
   
(defrule round-game ""
	(or(low-time no)
	(not (low-time ?)))
	(or(survival-games yes)
	(and(rhythm-games yes)
	(story-games no))
	(and(story-games yes)
	(rhythm-games no)))
	(not (finalAnswer ?))
	=>
	(assert (round-game yes)))
   
(defrule determine-round-game ""
	(low-time no)
	(survival-games no)
	(not (finalAnswer ?))
	=>
	(assert (round-game no)))   
;;;****************
;;;* Final answers *
;;;***
(defrule coop-games ""
	(low-time yes)
	(timing-rest yes)
	(not (finalAnswer ?))
	=>
	(assert (finalAnswer "List of cooperation games: Arizona Sunshine, SuriusSam VR, Forest, etc.")))
   
(defrule trial-games ""
	(low-time no)
	(round-game no)
	(not (finalAnswer ?))
	=>
	(assert (finalAnswer "List of Trial Demo Games: Appolo 11 HD, Rick and Morty VR, etc.")))
   
(defrule simulators-games ""
	(or (round-game yes)
	(low-time yes))
	(timing-rest no)
	(not (finalAnswer ?))
	=>
	(assert (finalAnswer "List of simulators: BeatSiber, HotPoint, ElvinAssasin, etc.")))
   
   
   ;;;********************************
;;;* STARTUP AND CONCLUSION RULES *
;;;********************************

(defrule system-banner ""
  (declare (salience 10))
  =>
  (printout t crlf crlf)
  (printout t "Decision assistance system for choosing a game in a VR club ")
  (printout t crlf crlf))

(defrule print-finalAnswer ""
  (declare (salience 10))
  (finalAnswer ?item)
  =>
  (printout t crlf crlf)
  (printout t "Suggested:")
  (printout t crlf crlf)
  (format t " %s%n%n%n" ?item))
