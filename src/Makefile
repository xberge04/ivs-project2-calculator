
pack_name=xnacar00_xberge04_xsebel04_xforma14
path_calculator=calculator\calculator\bin\Release\calculator.exe
calc_name=.\Calculator\

.PHONY: all pack clean run

all: clean pack run

pack:
	cd .. ; cd ..; powershell -command "& {Compress-Archive$(calc_name) $(pack_name).zip}"
clean:
	cd .. ; cd ..; powershell -command "& {Remove-Item $(pack_name).zip}"
run:
	$(path_calculator)
	
	
	