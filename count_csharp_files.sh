#!/run/current-system/sw/bin/zsh

find **/*.cs > .file.txt

while read file
do
  filesNumber=$(($filesNumber + 1))
done < .file.txt
echo "Number of files: ${filesNumber}"
while read line
do
 loc=$(($loc + 1))
done < **/*.cs

echo "Lines of code: $loc"