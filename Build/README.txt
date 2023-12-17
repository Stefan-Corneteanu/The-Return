Here are some things I modified with respect to the module lessons:
-help works also if you give a verb as the second word (Test: type "Help Say")
-pressing "go north" 4 times became tedious so i implemented a Linux-like
command history (Test: type "Go south", type "Go north", press the up arrow
twice, press the down arrow 3 times)
-game flavour changes:
	Red text for impossible actions (Test: go south from the tree)
	Contextual flavour for the snake encounter (custom messages for trying
to leave the chapel while serpent is enabled, room description modified once
serpent is murdered, made serpent respond to the talkto command, made the
GOLDEN COINS item name as 2 separate words)
	Modified the ending of the game (wanted to be creative with this
miniproject, naturally I wouldn't modify a design with game designer approval, i
just wanted to be creative :) )
	Various different error messages for specific cases (having an error
message like "You can't use [insert_empty_or_whitespace_only_name_here]" felt
off. Try typing the use command without arguments)
-added an observelocation action to display current location details again
(Test: from the Tree location, type "Go south" and then "observelocation")
-added a quit action to quit the game
-FOR ALTERNATIVE ENDING, USE STAFF IN THE LAST STAGE OF THE DISCUSSION WITH THE
FERRYMAN.

Thank you for reading me and i hope you enjoy! :)