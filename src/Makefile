
pack_name=xnacar00_xberge04_xsebel04_xforma14
path_calculator=C:'Program Files (x86)'
path_to_exe=Calculator/calculator.exe
pack_names=src,profiling, mockup, plan, *.*

.PHONY: all pack clean run

all: clean pack run

pack:
	cd .. ; powershell -command "& {Compress-Archive $(pack_names) $(pack_name).zip}"
clean:
	cd .. ; powershell -command "& {Remove-Item $(pack_name).zip}"
run:
	cd $(path_calculator) && ./$(path_to_exe)
	
	
	