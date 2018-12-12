import os,shutil

srcroot='/home/dm/SYSU-HW/ModernWeb'

for folder in os.listdir(srcroot):
	for file in os.listdir(os.path.join(srcroot,folder)):
		if file == '.git':
			shutil.rmtree(os.path.join(srcroot,folder,file))