# build: mono, gtk-sharp-3
# runtime: mono, gtk-sharp-3, gtk-layer-shell

mcs '-recurse:*.cs' -pkg:gtk-sharp-3.0 -out:power-menu
if [[ $? -eq 0 ]]; then
	chmod 755 ./power-menu
	sudo chown root:root ./power-menu
	sudo mv ./power-menu /usr/local/bin
else
	echo "Build failed."
	exit 1
fi
