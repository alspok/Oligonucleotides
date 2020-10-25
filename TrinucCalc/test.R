args <- commandArgs(TRUE)
args

setwd("/home/alvydas/Projects/R")
getwd()

cdsframe <- read.table(args[1])
cdsframe
ncdsframe <- read.table(args[2])
ncdsframe

#pdf(file = "frame.pdf")

boxplot(cdsframe$V2, ncdsframe$V2,
               cdsframe$V3, ncdsframe$V3,
               cdsframe$V4, ncdsframe$V4,
               cdsframe$V5, ncdsframe$V5,
               notch=TRUE,
               col="lightblue")                   

boxplot(cdsframe$V2, cdsframe$V3,
               cdsframe$V4, cdsframe$V5,
                noch=TRUE,
                col="lightblue")
                
dev.off()

#system("zathura frame.pdf")
