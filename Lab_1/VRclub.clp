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
   =>
   (assert (story-games (yes-or-no-p "Do you want to play in story games? (yes/no) "))))
   
(defrule determine-coop-mode ""
   (story-games no)
   =>
   (assert (coop-mode (yes-or-no-p "Would you like to play cooperative games? (yes/no) "))))
   
(defrule determine-dancing ""
   =>
   (assert (dancing (yes-or-no-p "Would you like to dance during the games? (yes/no) "))))
   
(defrule determine-listening-music ""
   (dancing no)
   =>
   (assert (listening-music (yes-or-no-p "Do you want to listen music during the games? (yes/no) "))))
 
(defrule determine-timing ""
   =>
   (assert (timing (ask-question "How much time do you plan to spend in a VR-club (15m, 30m, 60m+) ? " 15 30 60))))
   
(defrule determine-friends ""
   (dancing no)
   (listening-music no)
   =>
   (assert (friends (yes-or-no-p "Have you come with friends? (yes/no) "))))
   
   
(defrule determine-vest-problem ""
   (story-games no)
   (coop-mode yes)
   =>
   (assert (vest-problem (yes-or-no-p "Do you have a problem with the vestibular apparatus? (yes/no) "))))
   
(defrule determine-violence ""
   (vest-problem no)
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
		  (coop-mode yes))
   =>
   (assert (story-coop yes)))
   
(defrule determine-story-coop ""
   (and (story-games no)
   (and (story-games no)
   (coop-mode no))
   =>
   (assert (story-coop no)))
   
(defrule rhythm-games ""
	(or (dancing yes)
	(listening-music yes)
	(friends yes))
	=>
	(assert (rhythm-games yes)))
   
(defrule determine-rhythm-games ""
	(dancing no)
	(listening-music no)
	(friends no)
	=>
	(assert (rhythm-games no)))
   
(defrule low-time ""
	(story-games yes)
	(rhythm-games yes)
    =>
	(assert (low-time yes)))
   
(defrule determine-low-time ""
	(rhythm-games no)
	(story-games no)
	=>
	(assert (low-time no)))
   
(defrule survival-games ""
	(or (vest-problem yes)
	(violence yes))
	=>
	(assert (survival-games yes)))
   
(defrule determine-survival-games ""
	(vest-problem no)
	(violence no)
	=>
	(assert (survival-games no)))
   
(defrule round-game ""
	(low-time no)
	(or(survival-games yes)
	(and(rhythm-games yes)
	(story-games no))
	(and(story-games yes)
	(rhythm-games no)))
	=>
	(assert (round-game yes)))
   
(defrule determine-round-game ""
	(low-time no)
	(survival-games no)
	=>
	(assert (round-game no)))   
;;;****************
;;;* Final answers *
;;;***
(defrule coop-games ""
	(low-time yes)
	(timing-rest yes)
	=>
	(assert (finalAnswer "List of cooperation games: Arizona Sunshine, SuriusSam VR, Forest, etc.")))
   
(defrule trial-games ""
	(low-time no)
	(round-game no)
	=>
	(assert (finalAnswer "List of Trial Demo Games: Appolo 11 HD, Rick and Morty VR, etc.")))
   
(defrule simulators-games ""
	(or (round-game yes)
	(low-time yes))
	(timing-rest no)
	=>
	(assert (finalAnswer "List of simulators: BeatSiber, HotPoint, ElvinAssasin, etc.")))
	
(defrule no-finalAnswer ""
  (declare (salience -10))
  (not (finalAnswer ?))
  =>
  (assert (finalAnswer "Fuck this life! ")))   
   
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
